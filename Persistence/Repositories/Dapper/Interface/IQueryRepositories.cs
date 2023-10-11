

using Persistence.Repositories.Dapper.Tables.Interfaces;

namespace Persistence.Repositories.Dapper.Interface;

public interface IQueryRepositories
{
    ITaskRepository TaskRepository { get; }
    ITaskFileRepository taskFileRepository { get; }
    IUserTaskRepository UserTaskRepository { get; }
}