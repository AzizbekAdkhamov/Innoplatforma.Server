using Innoplatforma.Server.Data.DbContexts;
using Innoplatforma.Server.Data.IRepositories.Organizations.OrganizationDetails;
using Innoplatforma.Server.Domain.Entities.Organizations;

namespace Innoplatforma.Server.Data.Repositories.Organizations.OrganizationDetails;

public class OrganizationDetailRepository : Repository<OrganizationDetail, long>, IOrganizationDetailRepository
{
    public OrganizationDetailRepository(InnoPlatformDbContext dbContext) : 
        base(dbContext)
    {
    }
}
