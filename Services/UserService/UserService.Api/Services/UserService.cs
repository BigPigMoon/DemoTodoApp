using UserService.Entities;
using UserService.Repositories;

namespace UserService.Services
{
    public class UsersService(UserRepository userRepository)
    {
        private readonly UserRepository _userRepository = userRepository;

        public async Task<User> CreateNewUserAsync(User user, CancellationToken cancellationToken = default)
        {
            return await _userRepository.CreateAsync(user, cancellationToken);
        }

        public async Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            return await _userRepository.GetAllAsync(cancellationToken);
        }

        public async Task<User> GetUserAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _userRepository.GetByIdAsync(id, cancellationToken) ?? throw new KeyNotFoundException($"User by {id}not found");
        }

        public async Task DeleteUserAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _userRepository.DeleteAsync(id, cancellationToken);
        }
    }
}
