using Innoplatforma.Server.Data.DbContexts;
using Innoplatforma.Server.Data.IRepositories.Sections;
using Innoplatforma.Server.Domain.Entities.Sections;

namespace Innoplatforma.Server.Data.Repositories.Sections;

public class SectionRepository : Repository<Section, short>, ISectionRepository
{

    public SectionRepository(InnoPlatformDbContext dbContext) :
        base(dbContext)
    {
    }
}