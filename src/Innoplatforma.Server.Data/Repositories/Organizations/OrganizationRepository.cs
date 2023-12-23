using Innoplatforma.Server.Data.DbContexts;
using Innoplatforma.Server.Data.IRepositories.Organizations;
using Innoplatforma.Server.Domain.Entities.Organizations;

namespace Innoplatforma.Server.Data.Repositories.Organizations;

public class OrganizationRepository : Repository<Organization, long>, IOrganizationRepository
{
    public OrganizationRepository(InnoPlatformDbContext dbContext) : 
        base(dbContext)
    {
    }
}
