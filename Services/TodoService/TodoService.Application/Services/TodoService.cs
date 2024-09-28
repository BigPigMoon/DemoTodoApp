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
        return await _todoRepository.GetTodosByStatusAsync(status, cancellationToken);
    }

    public async Task<IEnumerable<Todo>> GetUserTodosAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        _ = await _userRepository.GetByIdAsync(userId, cancellationToken) ?? throw new KeyNotFoundException($"User by {userId} not found");

        return await _todoRepository.GetUserTodosAsync(userId, cancellationToken);
    }

    public async Task<Todo> CreateTodoAsync(Todo todo, CancellationToken cancellationToken = default)
    {
        return await _todoRepository.CreateAsync(todo, cancellationToken);
    }

    public async Task DeleteTodoAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _todoRepository.DeleteAsync(id, cancellationToken);
    }

    public async Task<Todo> SetTodoStatusAsync(Guid id, TodoStatus status, CancellationToken cancellationToken = default)
    {
        var todo = await _todoRepository.GetByIdAsync(id, cancellationToken) ?? throw new KeyNotFoundException($"Todo by {id} not found");
        todo.Status = status;
        await _todoRepository.UpdateAsync(todo, cancellationToken);

        return todo;
    }

    public async Task<Todo> UpdateTodoAsync(Todo item, CancellationToken cancellationToken = default)
    {
        var todo = await _todoRepository.GetByIdAsync(item.Id, cancellationToken) ?? throw new KeyNotFoundException($"Todo by {item.Id} not found");
        todo.Title = item.Title;
        todo.Deadline = item.Deadline;
        todo.UserId = item.UserId;

        await _todoRepository.UpdateAsync(todo, cancellationToken);

        return todo;
    }
}
