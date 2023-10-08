using Domain.Entities.TMS;
using Microsoft.AspNetCore.Http;

namespace Business.Services.TaskServices.Interface;

public interface ITaskModifyService
{
    void SetId(Guid id);
    Task MoveStatus(int status);
    Task ChangeLevel(int level);
    Task UpdateTask(TaskEntity task, List<TaskFileEntity> files);
    Task UploadFile(IFormFile file);
}