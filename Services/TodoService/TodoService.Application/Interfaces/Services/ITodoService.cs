using TodoService.Domain.Entities;

namespace TodoService.Application.Interfaces.Services;

public interface ITodosService
{
    Task<IEnumerable<Todo>> GetAllTodosAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Todo>> GetTodosByStatusAsync(TodoStatus status, CancellationToken cancellationToken = default);
    Task<IEnumerable<Todo>> GetUserTodosAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Todo> CreateTodoAsync(Todo todo, CancellationToken cancellationToken = default);
    Task<Todo> SetTodoStatusAsync(Guid id, TodoStatus status, CancellationToken cancellationToken = default);
    Task DeleteTodoAsync(Guid id, CancellationToken cancellationToken = default);
}
