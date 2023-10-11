using Domain.Entities.TMS;
using Persistence.Repositories.Dapper.Interface;

namespace Persistence.Repositories.Dapper.Tables.Interfaces;

public interface IUserTaskRepository: IRepositoryBase<UserTaskEntity>
{
    
}