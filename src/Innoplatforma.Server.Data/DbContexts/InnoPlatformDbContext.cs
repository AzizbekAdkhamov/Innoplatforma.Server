using Innoplatforma.Server.Domain.Entities.Applications;
using Innoplatforma.Server.Domain.Entities.Assets;
using Innoplatforma.Server.Domain.Entities.Auth;
using Innoplatforma.Server.Domain.Entities.Organizations;
using Innoplatforma.Server.Domain.Entities.References;
using Innoplatforma.Server.Domain.Entities.Sections;
using Innoplatforma.Server.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Innoplatforma.Server.Data.DbContexts;

public class InnoPlatformDbContext : DbContext
{
    public InnoPlatformDbContext(DbContextOptions<InnoPlatformDbContext> options)
        : base(options)
    {
    }

    

    
}
