﻿using Innoplatforma.Server.Data.DbContexts;
using Innoplatforma.Server.Domain.Entities.Users;
using Innoplatforma.Server.Data.IRepositories.Users;

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
