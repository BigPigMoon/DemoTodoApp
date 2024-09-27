using TodoService.Application.Interfaces.Repositories;
using TodoService.Application.Interfaces.Services;
using TodoService.Domain.Entities;

namespace TodoService.Application.Services;

public class TodosService(ITodoRepository todoRepository, IUserRepository userRepository) : ITodosService
{
    private readonly ITodoRepository _todoRepository = todoRepository;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<IEnumerable<Todo>> GetAllTodosAsync(CancellationToken cancellationToken = default)
    {
        return await _todoRepository.GetAllAsync(cancellationToken);
    }

    public async Task<IEnumerable<Todo>> GetTodosByStatusAsync(TodoStatus status, CancellationToken cancellationToken = default)
    {
        return await _todoRepository.GetTodosWithStatus(status, cancellationToken);
    }

    public async Task<IEnumerable<Todo>> GetUserTodosAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        _ = await _userRepository.GetByIdAsync(userId, cancellationToken) ?? throw new KeyNotFoundException("User by id not found");

        return await _todoRepository.GetUserTodos(userId, cancellationToken);
    }

    public async Task<Todo> CreateTodoAsync(Todo todo, CancellationToken cancellationToken = default)
    {
        return await _todoRepository.CreateAsync(todo, cancellationToken);
    }

    public async Task DeleteTodoAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _todoRepository.DeleteAsync(id, cancellationToken);
    }

    public Task<Todo> SetTodoStatusAsync(Guid id, TodoStatus status, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
