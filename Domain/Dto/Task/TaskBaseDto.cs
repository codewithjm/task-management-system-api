using Domain.Entities.TMS;

namespace Domain.Dto.Task;

public class TaskBaseDto
{
    public Guid ident { get; set; }
    public string task_title { get; set; }
    
    public string body { get; set; }
     
    public DateTime created_utc_date { get; set; }
    
    public DateTime? updated_utc_date { get; set; }
    
    public int task_status { get; set; } 
    public int task_level { get; set; }
    
    public DateTime due_date { get; set; }
     
    public int requestor_ident { get; set; }
    public UserEntity user { get; set; }
    public List<UserEntity> devs { get; set; }
}