using System.Data;

namespace Persistence.Repositories.Dapper.Configs;

public interface IDbConnectionFactory
{
    public Task<IDbConnection> CreateTmsConnectionAsync(); 
}