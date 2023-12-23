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
    DbSet<Investment> Investments { get; set; }
    DbSet<Application> Applications { get; set; }
    DbSet<ApplicationAsset> ApplicationAssets { get; set; }

    DbSet<Organization> Organizations { get; set; }
    DbSet<OrganizationDetail> OrganizationDetails { get; set; }
    DbSet<OrganizationDetailAsset> OrganizationDetailAssets { get; set; }

    DbSet<User> Users { get; set; }
    DbSet<UserAsset> UserAssets { get; set; }

    DbSet<Permission> Permissions { get; set;}

    DbSet<Role> Roles { get; set; }

    DbSet<RolePermession> RolePermessions { get; set; }

    DbSet<Link> Links { get; set; } 

    DbSet<Location> Locations { get; set; }

    DbSet<Section> Sections {  get; set; } 

    DbSet<PersonalData> PersonalData { get; set; }
    DbSet<UserProfession> UserProfessions { get;set; }
    DbSet<PersonalDataAssets> PersonalDataAssets { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Task.Run(() =>
        {
            SeedUsers(modelBuilder);
        }).Wait();
    }
    private void SeedUsers(ModelBuilder modelBuilder) 
    {
        
    }
}
