using Common.Database;
using UserService.Database;
using UserService.Entities;

namespace UserService.Repositories
{
    public class UserRepository(ApplicationDbContext dbContext) : BaseRepository<User, ApplicationDbContext>(dbContext)
    {
    }
}
