using System.Net;
using Business.Services.TaskServices.Interface; 
using Domain.Entities.TMS;
using Persistence.Repositories.EF.Interfaces;
using Utilities.Commons.Exceptions;
using Utilities.Utilities.Interfaces;

namespace Business.Services.TaskServices;

public class TaskCreateService : ITaskCreateService
{
    public TaskCreateService(IEntityWork entityWork, ILoggerUtil loggerUtil)
    {
        _entityWork = entityWork;
        _loggerUtil = loggerUtil;
    }


    private TaskEntity taskEntity;
    private List<TaskFileEntity> taskFileEntity;
    private List<UserTaskEntity> _userTaskEntities;
    private readonly IEntityWork _entityWork;
    private readonly ILoggerUtil _loggerUtil;
    
    
    
    public async Task CreateTask()
    {
        try
        {
            await _entityWork.TaskRepository.AddAsync(taskEntity);
            await _entityWork.TaskFileRepository.AddListAsync(taskFileEntity);
            await _entityWork.UserTaskRepository.AddListAsync(_userTaskEntities);
            await _entityWork.CommitAsync();
        }
        catch (Exception ex)
        {
            await _entityWork.RollBackAsync();
            _loggerUtil.WriteLogError(ex.Message);
            throw new ErrorException(HttpStatusCode.InternalServerError, ex.ToString());
        }
    }

    public void SetTaskData(TaskEntity taskEntity, List<TaskFileEntity> taskFileEntity)
    {
        throw new NotImplementedException();
    }

    public void SetTaskData(TaskEntity taskEntity, List<TaskFileEntity> taskFileEntity, List<UserTaskEntity> userTaskEntities)
    {
        this.taskEntity = taskEntity;
        this.taskFileEntity = taskFileEntity;
        this._userTaskEntities = userTaskEntities;
    }
}