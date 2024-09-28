using Common.Database;
using System.ComponentModel;

namespace TodoService.Domain.Entities
{
    public class Todo : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public TodoStatus Status { get; set; } = TodoStatus.Todo;
        public DateTime Deadline { get; set; }

        public Guid UserId { get; set; }
        public User Owner { get; set; } = null!;
    }

    public enum TodoStatus
    {
        [Description("Todo")]
        Todo,
        [Description("Doing")]
        Doing,
        [Description("Done")]
        Done,
    }

}
