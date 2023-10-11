using Domain.Dto.Task;
using Domain.Entities.TMS;

namespace Domain.DTO.Task.Output;

public class TaskOutputDto 
{
    
    public List<TaskBaseDto> openTasks { get; set; }
    public List<TaskBaseDto> inProgressTasks { get; set; }
    public List<TaskBaseDto> reviewTasks { get; set; }
    public List<TaskBaseDto> closeTasks { get; set; }
    public List<UserEntity> users { get; set; }
    
    
}