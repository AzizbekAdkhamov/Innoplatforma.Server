using Innoplatforma.Server.Data.DbContexts;
using Innoplatforma.Server.Domain.Entities.Users;
using Innoplatforma.Server.Data.IRepositories.Users;

namespace Innoplatforma.Server.Data.Repositories.Users;

public class PersonalDataRepository : Repository<PersonalData, long>, IPersonalDataRepository
{
    public PersonalDataRepository(InnoPlatformDbContext dbContext) :
        base(dbContext)
    {
    }
}
