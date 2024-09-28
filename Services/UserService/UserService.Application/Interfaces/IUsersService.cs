using UserService.Domain.Entities;

namespace UserService.Application.Interfaces;

public interface IUsersService
{
    Task<User> CreateNewUserAsync(User user, CancellationToken cancellationToken = default);
    Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken = default);
    Task<User> GetUserAsync(Guid id, CancellationToken cancellationToken = default);
    Task DeleteUserAsync(Guid id, CancellationToken cancellationToken = default);
}
