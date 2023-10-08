using Persistence.Repositories.Dapper.Configs;
using Persistence.Repositories.Dapper.Interface;
using Persistence.Repositories.Dapper.Tables;
using Persistence.Repositories.Dapper.Tables.Interfaces;

namespace Persistence.Repositories.Dapper;

public class QueryRepositories : IQueryRepositories
{
    private readonly IDbConnectionFactory _connectionFactory;

    public QueryRepositories(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public ITaskRepository TaskRepository => new TaskRepository(_connectionFactory);
    public ITaskFileRepository taskFileRepository => new TaskFileRepository(_connectionFactory);
}