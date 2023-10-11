namespace Domain.Dto.Task;

public class TaskFileBaseDto
{
    public Guid ident { get; set; }
    
    public Guid task_ident { get; set; }
    
    public string file_name { get; set; }

    public DateTime created_utc_date { get; set; } 
}