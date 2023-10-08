using Domain.Entities.TMS;
using Persistence.Repositories.EF.Interfaces;

namespace Persistence.Repositories.EF.Tables.Interface;

public interface ITaskRepository : IRepository<TaskEntity>
{
    
}