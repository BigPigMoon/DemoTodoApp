using Common.Database;

namespace TodoService.Domain.Entities
{
    public class User : BaseEntity
    {
        public ICollection<Todo> Todos { get; set; } = [];
    }
}
