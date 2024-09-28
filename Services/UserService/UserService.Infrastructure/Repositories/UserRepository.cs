using Common.Database;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Infrastructure.Database;

namespace UserService.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : BaseRepository<User, ApplicationDbContext>(dbContext), IUserRepository
{
}
