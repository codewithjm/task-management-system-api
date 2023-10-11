using Domain.Entities.TMS;
using Persistence.Contexts;
using Persistence.Repositories.EF.Tables.Interface;

namespace Persistence.Repositories.EF.Tables;

public class UserTaskRepository :  Repository<UserTaskEntity>, IUserTaskRepository
{
    public UserTaskRepository(TmsDbContext dbContext) : base(dbContext)
    {
    }
}