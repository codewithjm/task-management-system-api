using System.Net;
using Business.Services.TaskServices.Interface;
using Domain.Entities.TMS;
using Persistence.Repositories.Dapper.Interface;
using Persistence.Repositories.EF.Interfaces;
using Utilities.Commons.Exceptions;
using Utilities.Helpers.Interface;
using Utilities.Utilities.Interfaces;

namespace Business.Services.TaskServices;

public class TaskRemoveService : ITaskRemoveService
{
    public TaskRemoveService(IEntityWork entityWork, IQueryRepositories queryRepositories, ILoggerUtil loggerUtil, IFileHelper fileHelper)
    {
        _entityWork = entityWork;
        _queryRepositories = queryRepositories;
        _loggerUtil = loggerUtil;
        _fileHelper = fileHelper;
    }


    private readonly IEntityWork _entityWork;
    private readonly IQueryRepositories _queryRepositories;
    private readonly ILoggerUtil _loggerUtil;
    private readonly IFileHelper _fileHelper;
    
    private Guid fileId { get; set; }
    private Guid taskId { get; set; }

    public Task RemoveAsync()
    {
        throw new NotImplementedException();
    }

    public async Task FileRemoveAsync()
    {
        try
        {
            var result = await GetSingleTaskFileAsync();

            if (result != null)
            {
                _fileHelper.Delete(result.PATH);
                _entityWork.TaskFileRepository.DeleteAsync(result);
                await _entityWork.CommitAsync();
            }
        }
        catch (Exception ex)
        {
            await _entityWork.RollBackAsync();
            _loggerUtil.WriteLogError(ex.Message);
            throw new ErrorException(HttpStatusCode.InternalServerError, ex.ToString());
        }
    }

    public void setTaskId(Guid id)
    {
        this.taskId = id;
    }
    public void setFileId(Guid id)
    {
        this.fileId = id;
    }
    
    private async Task<TaskFileEntity?> GetSingleTaskFileAsync()
    {
        var result = await _queryRepositories.taskFileRepository.GetSingleAsync(@"WHERE ID = @id", new
        {
            id = fileId
        });
        return result;
    }
    
    
    private async Task<IEnumerable<TaskFileEntity>> GetTaskFileAsync()
    {
        var result = await _queryRepositories.taskFileRepository.GetAsync(@"WHERE TASK_REF = @id", new
        {
            id = taskId
        });
        return result;
    }
    
    private async Task<TaskEntity?> GetSingleTaskAsync()
    {
        var result = await _queryRepositories.TaskRepository.GetSingleAsync(@"WHERE ID = @id", new
        {
            id = taskId
        });
        return result;
    }
}