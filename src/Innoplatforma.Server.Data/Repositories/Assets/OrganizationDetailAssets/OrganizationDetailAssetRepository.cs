using Innoplatforma.Server.Data.DbContexts;
using Innoplatforma.Server.Data.IRepositories.Assets.OrganizationDetailAssets;
using Innoplatforma.Server.Domain.Entities.Assets;

namespace Innoplatforma.Server.Data.Repositories.Assets.OrganizationDetailAssets;

public class OrganizationDetailAssetRepository : Repository<OrganizationDetailAsset, long>, IOrganizationDetailAssetRepository
{
    public OrganizationDetailAssetRepository(InnoPlatformDbContext dbContext) : 
          base(dbContext)
    {
    }
}
