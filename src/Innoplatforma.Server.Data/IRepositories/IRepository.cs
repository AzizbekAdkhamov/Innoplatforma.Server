﻿using Innoplatforma.Server.Domain.Commons;

namespace Innoplatforma.Server.Data.IRepositories;

public interface IRepository<TEntity, TKey> where TEntity : Auditable<TKey>
{
    Task<bool> DeleteAsync(TKey id);
    IQueryable<TEntity> SelectAll();
    Task<TEntity> SelectByIdAsync(TKey id);
    Task<TEntity> InsertAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
}
