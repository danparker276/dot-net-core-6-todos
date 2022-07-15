using dp.business.Enums;

namespace dp.business.Models
  
{
    public class TodoItemRequest
    {
        public string Description { get; set; }
        public int TodoListId { get; set; }
    }
    public class TodoItemEditRequest
    {
        public string Description { get; set; }
        public int TodoItemId { get; set; }
    }
    public class TodoItemStatusRequest
    {
        public int Status { get; set; }
        public int TodoItemId { get; set; }
    }
    public class ResponseId
    {
        public int Id { get; set; }
    }
}