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
    public DbSet<Investment> Investments { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<ApplicationAsset> ApplicationAssets { get; set; }

    public DbSet<Organization> Organizations { get; set; }
    public DbSet<OrganizationDetail> OrganizationDetails { get; set; }
    public DbSet<OrganizationDetailAsset> OrganizationDetailAssets { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Permission> Permissions { get; set;}

    public DbSet<Role> Roles { get; set; }

    public DbSet<RolePermession> RolePermessions { get; set; }

    public DbSet<Link> Links { get; set; } 

    public DbSet<Location> Locations { get; set; }

    public DbSet<Section> Sections {  get; set; } 

    public DbSet<PersonalData> PersonalData { get; set; }
    public DbSet<UserProfession> UserProfessions { get;set; }
    public DbSet<PersonalDataAssets> PersonalDataAssets { get; set; }
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
