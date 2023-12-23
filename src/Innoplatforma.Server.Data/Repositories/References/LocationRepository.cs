using Innoplatforma.Server.Data.DbContexts;
using Innoplatforma.Server.Domain.Entities.References;
using Innoplatforma.Server.Data.IRepositories.References;

namespace Innoplatforma.Server.Data.Repositories.References;

public class LocationRepository : Repository<Location, long>, ILocationRepository
{
    public LocationRepository(InnoPlatformDbContext dbContext) :
        base(dbContext)
    {
    }
}
