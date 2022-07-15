using dataEF.Models;
using dp.api.Authorization;
using dp.api.Services;
using dp.business.Enums;
using dp.business.Models;
using Microsoft.AspNetCore.Mvc;

namespace dp.api.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : BaseController
    {
        private ITodoListService _todoListService;

        public TodoItemsController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }

        [Authorize(Role.User)]
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetTodoItems(int listId)
        {
            var currentUser = GetClaimedUser();
            var todoList = await _todoListService.GetTodoListByListId(listId);
            if (todoList.UserId != currentUser.UserId)
            {
                return Unauthorized();
            }
            var ret = await _todoListService.GetTodoItems(listId);
            return Ok(ret);
        }

        [Authorize(Role.User)]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateTodoItem(TodoItemRequest todoItemRequest)
        {
            var currentUser = GetClaimedUser();
            //We will keep Status at defulat
            var todoList = await _todoListService.GetTodoListByListId(todoItemRequest.TodoListId);
            TodoItem todoItem = new TodoItem() { Description = todoItemRequest.Description, TodoListId = todoItemRequest.TodoListId, TodoList = todoList };
            int newId = await _todoListService.CreateTodoItem(todoItem);
            return Ok(new ResponseId() { Id = newId });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Role.Admin)]
        [HttpGet("/adminall")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAllTodoLists()
        {

            var ret = await _todoListService.GetAllTodoItems();
            return Ok(ret);
        }


        [Authorize(Role.User)]
        [HttpPut("description")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> EditTodoItem(TodoItemEditRequest todoItemEditRequest)
        {
            var currentUser = GetClaimedUser();

            var todoItem = await _todoListService.GetTodoItem(todoItemEditRequest.TodoItemId);
            todoItem.Description = todoItemEditRequest.Description;
            await _todoListService.EditTodoItem(todoItem);
            return Ok();
        }

        /// <summary>
        /// This will change or toggle the status of the todo item 
        /// A -1 status is for delete
        /// </summary>
        /// <param name="todoItemStatusRequest"></param>
        /// <returns></returns>
        [Authorize(Role.User)]
        [HttpPut("status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> EditTodoItemStatus(TodoItemStatusRequest todoItemStatusRequest)
        {
            var currentUser = GetClaimedUser();

            var todoItem = await _todoListService.GetTodoItem(todoItemStatusRequest.TodoItemId);
            todoItem.Status = todoItemStatusRequest.Status;
            await _todoListService.EditTodoItem(todoItem);
            return Ok();
        }

    }
}