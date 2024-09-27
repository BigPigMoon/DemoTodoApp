using Common.Database;
using TodoService.Domain.Entities;

namespace TodoService.Application.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
}
