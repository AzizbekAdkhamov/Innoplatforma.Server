using Innoplatforma.Server.Data.DbContexts;
using Innoplatforma.Server.Domain.Entities.Users;
using Innoplatforma.Server.Data.IRepositories.Users;

namespace Innoplatforma.Server.Data.Repositories.Users
{
    public class ProfessionRepository : Repository<Profession, int>, IProfessionRepository
    {
        public ProfessionRepository(InnoPlatformDbContext dbContext) :
            base(dbContext)
        {
        }
    }
}
