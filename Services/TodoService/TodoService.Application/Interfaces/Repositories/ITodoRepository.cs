using Common.Database;
using TodoService.Domain.Entities;

namespace TodoService.Application.Interfaces.Repositories;

public interface ITodoRepository : IRepository<Todo>
{
    Task<IEnumerable<Todo>> GetUserTodos(Guid userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Todo>> GetTodosWithStatus(TodoStatus status, CancellationToken cancellationToken = default);
}
