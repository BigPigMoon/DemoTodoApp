using Common.Database;
using TodoService.Application.Interfaces.Repositories;
using TodoService.Domain.Entities;
using TodoService.Infrastructure.Database;

namespace TodoService.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : BaseRepository<User, ApplicationDbContext>(dbContext), IUserRepository
{

}
