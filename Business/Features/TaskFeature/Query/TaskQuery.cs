using Business.Services.Mapper;
using Business.Services.User.Interface;
using Domain.Dto.Task;
using Domain.DTO.Task.Output;
using Domain.Entities.TMS;
using MediatR;
using Persistence.Repositories.Dapper.Interface;
using Utilities.Commons.Enums;
using Utilities.Helpers.Interface;

namespace Business.Features.TaskFeature.Query;

public class TaskQuery : IRequest<TaskOutputDto>
{
    
}

public class TaskQueryHandler : IRequestHandler<TaskQuery, TaskOutputDto>
{
    public TaskQueryHandler(IQueryRepositories queryRepositories, IEntityMapper entityMapper, IUserService userService, IFileHelper fileHelper)
    {
        _queryRepositories = queryRepositories;
        _entityMapper = entityMapper;
        _userService = userService;
        _fileHelper = fileHelper;
    }


    private readonly IQueryRepositories _queryRepositories;
    private readonly IEntityMapper _entityMapper;
    private readonly IUserService _userService;
    private readonly IFileHelper _fileHelper;
    
    
    public async Task<TaskOutputDto> Handle(TaskQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _queryRepositories.TaskRepository.GetAsync("");
        var devTasks = await _queryRepositories.UserTaskRepository.GetAsync(@"
            WHERE [TASK_REF] IN @ids
        ", new
        {
            ids = tasks.Select(x => x.ID).ToList()
        });
        var result = new TaskOutputDto();
        result.users = _userService.get(); 
        var mappedData = tasks.Select(x =>
        {
            var tmp = _entityMapper._taskMapper.Map(x);
            tmp.user = result.users.Find(z => z.ID == x.REQUESTOR);
            tmp.devs = devTasks.Where(y => y.TASK_REF == x.ID).Select(v =>
            {
                var devDetails = result.users.Find(m => m.ID == v.USER_REF);
                var dvs = new UserEntity
                {
                    ID = v.ID,
                    FIRST_NAME = devDetails.FIRST_NAME,
                    LAST_NAME = devDetails.FIRST_NAME,
                    POSITION = devDetails.POSITION,
                    IMG_PATH = devDetails.IMG_PATH
                };
                return dvs;
            }).ToList();
            
            try
            {
                tmp.body = _fileHelper.ReadText(x.BODY_PATH);
            }
            catch
            {
                tmp.body = string.Empty;
            }
            
            return tmp;
        }).ToList();

        result.openTasks = mappedData.Where(x => x.task_status == (int)TaskStatusEnum.Open).ToList();
        result.inProgressTasks = mappedData.Where(x => x.task_status == (int)TaskStatusEnum.InProgress).ToList();
        result.closeTasks = mappedData.Where(x => x.task_status == (int)TaskStatusEnum.Close).ToList();
        result.reviewTasks = mappedData.Where(x => x.task_status == (int)TaskStatusEnum.Review).ToList();
        
        return result;
    }
}