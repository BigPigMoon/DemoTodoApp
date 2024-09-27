using Common.Database;
using Microsoft.EntityFrameworkCore;
using TodoService.Application.Interfaces.Repositories;
using TodoService.Domain.Entities;
using TodoService.Infrastructure.Database;

namespace TodoService.Infrastructure.Repositories;

public class TodoRepository(ApplicationDbContext context) : BaseRepository<Todo, ApplicationDbContext>(context), ITodoRepository
{
    public async Task<IEnumerable<Todo>> GetTodosWithStatus(TodoStatus status, CancellationToken cancellationToken = default)
    {
        return await _context.Todos.Where(t => t.Status == status).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Todo>> GetUserTodos(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _context.Todos.Where(t => t.UserId == userId).ToListAsync(cancellationToken);
    }
}
