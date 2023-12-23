using Innoplatforma.Server.Data.DbContexts;
using Innoplatforma.Server.Data.IRepositories.Users;
using Innoplatforma.Server.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatforma.Server.Data.Repositories.Users
{
    public class UserRepository : Repository<User, long>, IUserRepository
    {
        public UserRepository(InnoPlatformDbContext dbContext) :
            base(dbContext)
        {
        }
    }
}
