using Common.Contracts;
using MassTransit;
using TodoService.Application.Interfaces.Repositories;

namespace TodoService.Infrastructure.Consumers
{
    internal class UserDeletedConsumer(IUserRepository userRepository) : IConsumer<UserDeleted>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task Consume(ConsumeContext<UserDeleted> context)
        {
            await _userRepository.DeleteAsync(context.Message.Id);
        }
    }
}
