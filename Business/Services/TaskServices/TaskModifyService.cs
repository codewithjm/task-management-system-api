using System.Net;
using Business.Services.TaskServices.Interface;
using Domain.Entities.TMS;
using Microsoft.AspNetCore.Http;
using Persistence.Repositories.Dapper.Interface;
using Persistence.Repositories.EF.Interfaces;
using Utilities.Commons.Exceptions;
using Utilities.Utilities.Interfaces;

namespace Business.Services.TaskServices;

public class TaskModifyService : ITaskModifyService
{
    public TaskModifyService(IEntityWork entityWork, IQueryRepositories queryRepositories, ILoggerUtil loggerUtil)
    {
        _entityWork = entityWork;
        _queryRepositories = queryRepositories;
        _loggerUtil = loggerUtil;
    }

    private readonly IEntityWork _entityWork;
    private readonly IQueryRepositories _queryRepositories;
    private readonly ILoggerUtil _loggerUtil;
    
    private  Guid Id { get; set; }
    
    
    
    public TaskModifyService(Guid id)
    {
        Id = id;
    }

    public void SetId(Guid id)
    {
        this.Id = id;
    }

    public async Task MoveStatus(int status)
    {
        var result = await GetSingleTaskAsync();

        if (result != null)
        {
            try
            {
                result.STATUS = status;
                result.UPDATED_UTC_DATE = DateTime.UtcNow;
                _entityWork.TaskRepository.UpdateAsync(result);
                await _entityWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _entityWork.RollBackAsync();
                _loggerUtil.WriteLogError(ex.Message);
                throw new ErrorException(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }

    public async Task ChangeLevel(int level)
    {
        var result = await GetSingleTaskAsync();

        if (result != null)
        {
            try
            {
                result.LEVEL = level;
                result.UPDATED_UTC_DATE = DateTime.UtcNow;
                _entityWork.TaskRepository.UpdateAsync(result);
                await _entityWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _entityWork.RollBackAsync();
                _loggerUtil.WriteLogError(ex.Message);
                throw new ErrorException(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }

    public async Task UpdateTask(TaskEntity task, List<TaskFileEntity> files)
    {
        try
        {
            _entityWork.TaskRepository.UpdateAsync(task);
            await _entityWork.CommitAsync();
        }
        catch (Exception ex)
        {
            await _entityWork.RollBackAsync();
            _loggerUtil.WriteLogError(ex.Message);
            throw new ErrorException(HttpStatusCode.InternalServerError, ex.ToString());
        }
        
        
    }

    public async Task UploadFile(IFormFile file)
    {
        throw new NotImplementedException();
    }


    private async Task<TaskEntity?> GetSingleTaskAsync()
    {
        var result = await _queryRepositories.TaskRepository.GetSingleAsync(@"WHERE ID = @id", new
        {
            id = Id
        });
        return result;
    }
}