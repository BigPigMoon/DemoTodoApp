using AutoMapper;
using Common.Contracts;
using MassTransit;
using TodoService.Application.Interfaces.Repositories;
using TodoService.Domain.Entities;

namespace TodoService.Infrastructure.Consumers
{
    internal class UserCreatedConsumer(IUserRepository userRepository, IMapper mapper) : IConsumer<UserCreated>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;

        public async Task Consume(ConsumeContext<UserCreated> context)
        {
            await _userRepository.CreateAsync(_mapper.Map<User>(context.Message));
        }
    }
}
