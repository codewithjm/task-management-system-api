using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Dapper;
using Domain.Entities.TMS;
using Persistence.Repositories.Dapper.Configs;
using Persistence.Repositories.Dapper.Interface;

namespace Persistence.Repositories.Dapper;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    protected readonly IDbConnectionFactory _connectionFactory;

    protected RepositoryBase(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }



    public async Task<IEnumerable<TEntity>> ReadDb(string query, object? obj)
    {
        var conn = await _connectionFactory.CreateTmsConnectionAsync();
        var result = await conn.QueryAsync<TEntity>(query, obj);
        conn?.Close();
        conn?.Dispose();
        return result;
    }

    public async Task<TEntity?> GetSingleAsync(string where, object? parameters = null)
    {
        using var connection = await _connectionFactory.CreateTmsConnectionAsync();
        var tableName = GetTableAttributeName();
        if (string.IsNullOrEmpty(tableName))
            throw new ArgumentNullException($"Table Attribute has not been set with this entity: {typeof(TEntity)}");

        return await connection.QuerySingleOrDefaultAsync<TEntity>($"SELECT TOP 1 * FROM {tableName} {where}", parameters);
    }

    public async Task<IEnumerable<TEntity>> GetAsync(string where, object? parameters = null)
    {
        using var connection = await _connectionFactory.CreateTmsConnectionAsync();
        var tableName = GetTableAttributeName();
        if (string.IsNullOrEmpty(tableName))
            throw new ArgumentNullException($"Table Attribute has not been set with this entity: {typeof(TEntity)}");

        return await connection.QueryAsync<TEntity>($"SELECT * FROM {tableName} {where}", parameters);
    }


    protected string GetTableAttributeName()
    {
        if (typeof(TEntity).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() is TableAttribute tableAttribute)
        {
            return tableAttribute.Name;
        }

        return string.Empty;
    }
}