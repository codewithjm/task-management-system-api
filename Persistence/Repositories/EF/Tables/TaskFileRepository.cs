using Domain.Entities.TMS;
using Persistence.Contexts;
using Persistence.Repositories.EF.Interfaces;
using Persistence.Repositories.EF.Tables.Interface;

namespace Persistence.Repositories.EF.Tables;

public class TaskFileRepository : Repository<TaskFileEntity>, ITaskFileRepository
{
    public TaskFileRepository(TmsDbContext dbContext) : base(dbContext)
    {
    }
}