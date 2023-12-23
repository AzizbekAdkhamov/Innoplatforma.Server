using Innoplatforma.Server.Data.DbContexts;
using Innoplatforma.Server.Data.IRepositories.Organizations.Links;
using Innoplatforma.Server.Domain.Entities.Organizations;

namespace Innoplatforma.Server.Data.Repositories.Organizations.Links;

public class LinkRepository : Repository<Link, long>, ILinkRepository
{
    public LinkRepository(InnoPlatformDbContext dbContext) : 
        base(dbContext)
    {
    }
}
