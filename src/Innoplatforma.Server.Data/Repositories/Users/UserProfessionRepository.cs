using Innoplatforma.Server.Data.DbContexts;
using Innoplatforma.Server.Data.IRepositories.Users;
using Innoplatforma.Server.Data.Repositories;
using Innoplatforma.Server.Domain.Entities.Users;

public class UserProfessionRepository : Repository<UserProfession, long>, IUserProfessionRepository
{
    public UserProfessionRepository(InnoPlatformDbContext dbContext) :
       base(dbContext)
    {
    }
}
