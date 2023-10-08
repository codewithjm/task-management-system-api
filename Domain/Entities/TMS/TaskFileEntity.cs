using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.TMS;

[Table("TASK_FILE")]
public class TaskFileEntity
{
    [Key]
    public Guid ID { get; set; }
    
    public Guid TASK_REF { get; set; }
    
    [Required] 
    public string FILE_NAME { get; set; }
    [Required] 
    public string PATH { get; set; }
    public DateTime CREATED_UTC_DATE { get; set; } 
}