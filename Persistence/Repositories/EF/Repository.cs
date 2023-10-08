
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories.EF.Interfaces;

namespace Persistence.Repositories.EF;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _entities;

    public Repository(TmsDbContext dbContext)
    {
        _entities = dbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity) => await _entities.AddAsync(entity);

    public async Task AddListAsync(IEnumerable<TEntity> entities) => await _entities.AddRangeAsync(entities);

    public void DeleteAsync(TEntity entity) => _entities.Remove(entity);

    public void DeleteListAsync(IEnumerable<TEntity> entities) => _entities.RemoveRange(entities);

    public  void UpdateAsync(TEntity entity) => _entities.Update(entity);

    public void PatchAsync(IEnumerable<TEntity> entities) => _entities.UpdateRange(entities);
}