using Dapper;
using Domain.Entities.TMS;
using Persistence.Repositories.Dapper.Configs;
using Persistence.Repositories.Dapper.Tables.Interfaces;

namespace Persistence.Repositories.Dapper.Tables;

public class TaskRepository : RepositoryBase<TaskEntity>, ITaskRepository
{
    public TaskRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }
    
}