
using Domain.Entities.TMS;

namespace Business.Services.TaskServices.Interface;

public interface ITaskCreateService
{
    Task CreateTask();
    void SetTaskData(TaskEntity taskEntity, List<TaskFileEntity> taskFileEntity);
}