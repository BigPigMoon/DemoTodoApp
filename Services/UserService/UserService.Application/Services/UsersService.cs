using AutoMapper;
using Common.Contracts;
using MassTransit;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;

namespace UserService.Application.Services;

public class UsersService(IUserRepository userRepository, IBus bus, IMapper mapper) : IUsersService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IBus _bus = bus;
    private readonly IMapper _mapper = mapper;

    public async Task<User> CreateNewUserAsync(User user, CancellationToken cancellationToken = default)
    {
        var newUser = await _userRepository.CreateAsync(user, cancellationToken);

        var message = _mapper.Map<UserCreated>(newUser);
        await _bus.Publish(message, cancellationToken);

        return newUser;
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
        await _bus.Publish(new UserDeleted { Id = id }, cancellationToken);
    }
}
