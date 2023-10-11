namespace Business.Services.TaskServices.Interface;

public interface ITaskRemoveService
{
    Task RemoveTaskAsync();
    Task FileRemoveAsync();
    void setTaskId(Guid id);
    void setFileId(Guid id);
}