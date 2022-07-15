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
    public class TodoListController : BaseController
    {
        private ITodoListService _todoListService;

        public TodoListController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }

        //
        [Authorize(Role.User)]
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetTodoLists()
        {
            var currentUser = GetClaimedUser();

            var ret = await _todoListService.GetTodoLists(currentUser.UserId);
            return Ok(ret);
        }

        [Authorize(Role.User)]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateList([Bind("Name")] TodoList todoList)
        {
            var currentUser = GetClaimedUser();
            todoList.UserId = currentUser.UserId;

            int newId = await _todoListService.CreateTodoList(todoList);
            return Ok(new ResponseId() { Id=newId });
        }



    }
}