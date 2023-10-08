namespace Persistence.Repositories.Dapper.Interface;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> ReadDb(string query, object? obj);

    Task<TEntity?> GetSingleAsync(string where, object? parameters = null);
    Task<IEnumerable<TEntity>> GetAsync(string where, object? parameters = null);
}