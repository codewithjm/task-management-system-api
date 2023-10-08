using Domain.Entities.TMS;
using Persistence.Repositories.EF.Tables.Interface;

namespace Persistence.Repositories.EF.Interfaces;

public interface IEntityWork : IDisposable
{
    ITaskFileRepository TaskFileRepository { get; }
    ITaskRepository TaskRepository { get; } 

    Task<int> CommitAsync();
    Task RollBackAsync();
}