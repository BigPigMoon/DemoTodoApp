using Common.Database;

namespace TodoService.Domain.Entities
{
    public class User : BaseEntity
    {
        public virtual IEnumerable<Todo> Todos { get; set; } = [];
    }
}
