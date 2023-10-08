using Domain.Entities.TMS;
using Persistence.Repositories.Dapper.Configs;
using Persistence.Repositories.Dapper.Tables.Interfaces;

namespace Persistence.Repositories.Dapper.Tables;

public class TaskFileRepository : RepositoryBase<TaskFileEntity>, ITaskFileRepository
{
    public TaskFileRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }
}