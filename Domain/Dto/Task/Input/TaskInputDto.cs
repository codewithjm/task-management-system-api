using Microsoft.AspNetCore.Http;

namespace Domain.Dto.Task.Input;

public class TaskInputDto
{
    public string task_title { get; set; }
    
    public string body { get; set; }
     
    public int task_status { get; set; } 
    public int task_level { get; set; }
    
    public DateTime due_date { get; set; }
     
    public int requestor_ident { get; set; }

    public List<IFormFile> files { get; set; } = new List<IFormFile>();
}