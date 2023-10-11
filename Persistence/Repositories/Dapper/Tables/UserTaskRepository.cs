using Domain.Entities.TMS;
using Persistence.Repositories.Dapper.Configs;
using Persistence.Repositories.Dapper.Tables.Interfaces;

namespace Persistence.Repositories.Dapper.Tables;

public class UserTaskRepository: RepositoryBase<UserTaskEntity>, IUserTaskRepository
{
    public UserTaskRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }
}