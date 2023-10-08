using Business.Services.TaskServices.Interface;

namespace Business.Services.TaskServices;

public class TaskCommentService : ITaskCommentService
{
    public void CreateComment()
    {
        
        throw new NotImplementedException();
    }
    
    private Guid Id { get; set; }
    private string? Comment { get; set; }
    private int UserId { get; set; }
}