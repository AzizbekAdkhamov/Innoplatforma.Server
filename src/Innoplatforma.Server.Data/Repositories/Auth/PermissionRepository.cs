using Innoplatforma.Server.Data.DbContexts;
using Innoplatforma.Server.Data.IRepositories.Auth;
using Innoplatforma.Server.Domain.Entities.Auth;

namespace Innoplatforma.Server.Data.Repositories.Auth;

public class PermissionRepository : Repository<Permission, int>, IPermissionRepository
{
    public PermissionRepository(InnoPlatformDbContext dbContext) : 
        base(dbContext)
    {
    }
}
