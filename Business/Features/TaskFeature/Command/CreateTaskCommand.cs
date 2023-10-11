using Business.Services.TaskServices.Interface;
using Domain.Dto.Task.Input;
using Domain.Entities.TMS;
using MediatR;
using Utilities.Commons.Consts;
using Utilities.Commons.Enums;
using Utilities.Helpers.Interface;
using Utilities.Wrappers.Interfaces;

namespace Business.Features.TaskFeature.Command;

public class CreateTaskCommand : IRequest
{
    public TaskInputDto input { get; set; } = null!;
}


public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand>
{
    public CreateTaskCommandHandler(ITaskCreateService taskCreateService, IFileHelper fileHelper, IPathWrapper pathWrapper)
    {
        _taskCreateService = taskCreateService;
        _fileHelper = fileHelper;
        _pathWrapper = pathWrapper;
    }

    private readonly ITaskCreateService _taskCreateService;
    private readonly IFileHelper _fileHelper;
    private readonly IPathWrapper _pathWrapper;
 

    public async Task<Unit> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        Guid generatedId = Guid.NewGuid();

        string path = generatedId.ToString();
        string bodyPath = $"{FileConst.DEFAULT_PATH}{path}";
        string bodyFileName = "task_body.txt";
        await _fileHelper.Write(bodyPath, request.input.body, bodyFileName);

        var taskFiles = new List<TaskFileEntity>();
        
        if (request.input.files.Count() > 0)
        {
            foreach (var file in request.input.files)
            {
                Guid fileId = Guid.NewGuid();
                string taskFilePath = $"{FileConst.DEFAULT_PATH}{path}\\{fileId}{_pathWrapper.GetExtension(file.FileName)}";
                await _fileHelper.Write(taskFilePath, file);
                taskFiles.Add(new TaskFileEntity
                {
                    ID = fileId,
                    TASK_REF = generatedId,
                    FILE_NAME = file.FileName,
                    PATH = taskFilePath,
                    CREATED_UTC_DATE = DateTime.UtcNow
                });
            } 
        }

        var devs = request.input.developers.Select(x => new UserTaskEntity
        {
            TASK_REF = generatedId,
            CREATED_UTC_DATE = DateTime.UtcNow,
            USER_REF = x
        }).ToList();
        
        _taskCreateService.SetTaskData(new TaskEntity
        {
            ID = generatedId,
            TITLE = request.input.task_title,
            BODY_PATH = $"{bodyPath}\\{bodyFileName}",
            CREATED_UTC_DATE = DateTime.UtcNow,
            STATUS = (int)TaskStatusEnum.Open,
            LEVEL = request.input.task_level,
            DUE_UTC_DATE = request.input.due_date,
            REQUESTOR = 3
        }, taskFiles, devs);
        
        await _taskCreateService.CreateTask();
        
        
        
        return await Task.FromResult(Unit.Value);
    }
}