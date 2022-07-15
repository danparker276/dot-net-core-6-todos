using dataEF.Models;
using Microsoft.EntityFrameworkCore;

namespace dp.api.Services
{
    public interface ITodoListService
    {

        Task<List<TodoList>> GetTodoLists(int userId);
        Task<List<TodoItem>> GetTodoItems(int listId);
        Task<int> CreateTodoList(TodoList todoList);
        Task<int> CreateTodoItem(TodoItem todoItem);
        Task<TodoList> GetTodoListByListId(int listId);
        Task<TodoItem> GetTodoItem(int itemId);
        Task EditTodoItem(TodoItem todoItem);
        Task<List<TodoItem>> GetAllTodoItems();

    }


    public class TodoListService : ITodoListService
    {

        private readonly todosContext _context;

        public TodoListService(todosContext context)
        {
            _context = context;

        }


        public async Task<List<TodoList>> GetTodoLists(int userId)
        {
            return await _context.TodoLists.Where(x => x.UserId == userId).ToListAsync();

        }
        public async Task<List<TodoItem>> GetTodoItems(int listId)
        {
            return await _context.TodoItems.Where(x => x.TodoListId == listId && x.Status >= 0).ToListAsync();

        }
        public async Task<List<TodoItem>> GetAllTodoItems()
        {
            return await _context.TodoItems.Where(x =>  x.Status >= 0).ToListAsync();

        }
        public async Task<TodoItem> GetTodoItem(int itemId)
        {
            return await _context.TodoItems.FindAsync(itemId);

        }

        public async Task<TodoList> GetTodoListByListId(int listId)
        {
            return  await _context.TodoLists.FindAsync(listId);

        }

        public async Task<int> CreateTodoList(TodoList todoList)
        {
            //TODO any validations/constraints

            _context.TodoLists.Add(todoList);
            await _context.SaveChangesAsync();
            return todoList.Id;
        }

        public async Task<int> CreateTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return todoItem.Id;
        }
        public async Task EditTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Update(todoItem);
            await _context.SaveChangesAsync();

        }

    }
}