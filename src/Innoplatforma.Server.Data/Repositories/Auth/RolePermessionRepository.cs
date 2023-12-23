using Innoplatforma.Server.Data.DbContexts;
using Innoplatforma.Server.Domain.Entities.Auth;
using Innoplatforma.Server.Data.IRepositories.Auth;

namespace Innoplatforma.Server.Data.Repositories.Auth;

public class RolePermesssionRepository : Repository<RolePermession, long>, IRolePermessionRepository
{
    public RolePermesssionRepository(InnoPlatformDbContext dbContext) :
        base(dbContext)
    {
    }
}
