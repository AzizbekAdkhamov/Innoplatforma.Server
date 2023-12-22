using Microsoft.EntityFrameworkCore;

namespace Innoplatforma.Server.Data.DbContexts;

public class InnoPlatformaDbContext : DbContext
{
    public InnoPlatformaDbContext(DbContextOptions<InnoPlatformaDbContext> options)
        : base(options)
    {
    }
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
