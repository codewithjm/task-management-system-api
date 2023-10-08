using System.Data;
using System.Data.SqlClient;

namespace Persistence.Repositories.Dapper.Configs;

public class SqlServerConnectionFactory : IDbConnectionFactory
{
    public SqlServerConnectionFactory(string tmsConnectionString)
    {
        _tmsConnectionString = tmsConnectionString;
    }


    private readonly string _tmsConnectionString; 


    public async Task<IDbConnection> CreateTmsConnectionAsync()
    {
        var connection = new SqlConnection(_tmsConnectionString);
        await connection.OpenAsync();

        return connection;
    }

}