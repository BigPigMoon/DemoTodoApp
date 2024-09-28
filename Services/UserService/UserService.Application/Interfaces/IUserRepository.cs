using Common.Database;
using UserService.Domain.Entities;

namespace UserService.Application.Interfaces;

public interface IUserRepository : IRepository<User>
{
}
