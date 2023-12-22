using Innoplatforma.Server.Data.DbContexts;
using Innoplatforma.Server.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Innoplatforma.Server.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly InnoPlatformaDbContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(InnoPlatformaDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }
    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        _dbSet.Remove(entity);

        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var entry = await _dbSet.AddAsync(entity);

        await _dbContext.SaveChangesAsync();

        return entry.Entity;
    }

    public IQueryable<TEntity> SelectAll() => _dbSet;

    public async Task<TEntity> SelectByIdAsync(long id)=>
        await _dbSet.FirstOrDefaultAsync(e => e.Id == id);

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var @object =  _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();

        return @object.Entity;
    }
}
