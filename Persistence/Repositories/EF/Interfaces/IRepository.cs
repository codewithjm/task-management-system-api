namespace Persistence.Repositories.EF.Interfaces;

public  interface IRepository<in TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task AddListAsync(IEnumerable<TEntity> entities);

    void DeleteAsync(TEntity entity);
    void DeleteListAsync(IEnumerable<TEntity> entities);

    
    void UpdateAsync(TEntity entity);
    void PatchAsync(IEnumerable<TEntity> entities);
}