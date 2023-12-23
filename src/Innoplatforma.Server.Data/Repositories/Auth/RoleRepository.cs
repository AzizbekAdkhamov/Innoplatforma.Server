using Innoplatforma.Server.Data.DbContexts;
using Innoplatforma.Server.Domain.Entities.Auth;
using Innoplatforma.Server.Data.IRepositories.Auth;

namespace Innoplatforma.Server.Data.Repositories.Auth;

public class RoleRepository : Repository<Role, short>, IRoleRepository
{
    public RoleRepository(InnoPlatformDbContext dbContext) :
        base(dbContext)
    {
    }
}
