using System.Text.Json.Serialization;

namespace dataEF.Models
{
    public partial class TodoItem
    {
        public int Id { get; set; }
        public int TodoListId { get; set; }
        public DateTime Created { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; }
        [JsonIgnore]
        public virtual TodoList TodoList { get; set; } = null!;
    }
}
