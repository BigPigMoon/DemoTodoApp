using Common.Database;

namespace TodoService.Domain.Entities
{
    public class Todo : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public TodoStatus Status { get; set; } = TodoStatus.Todo;
        public DateTime Deadline { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }

    public enum TodoStatus
    {
        Todo,
        Doing,
        Done,
    }

}
