using Domain.Entities.TMS;
using Persistence.Contexts;
using Persistence.Repositories.EF.Tables.Interface;

namespace Persistence.Repositories.EF.Tables;

public class TaskRepository : Repository<TaskEntity>, ITaskRepository
{
    public TaskRepository(TmsDbContext dbContext) : base(dbContext)
    {
    }
}