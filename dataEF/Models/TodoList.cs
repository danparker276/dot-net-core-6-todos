using System;
using System.Collections.Generic;

namespace dataEF.Models
{
    public partial class TodoList
    {
        public TodoList()
        {
            TodoItems = new HashSet<TodoItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int UserId { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
