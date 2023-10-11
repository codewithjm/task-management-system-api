using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.TMS;

[Table("TASK")]
public class TaskEntity
{
    [Key]
    public Guid ID { get; set; }
    
    [Required]
    [StringLength(150)]
    public string TITLE { get; set; }
    
    public string BODY_PATH { get; set; }
    
    public DateTime CREATED_UTC_DATE { get; set; }
    public DateTime? UPDATED_UTC_DATE { get; set; }
    
    [Required] 
    public int STATUS { get; set; }
    [Required] 
    public int LEVEL { get; set; }
    
    public DateTime DUE_UTC_DATE { get; set; }
    
    [Required] 
    public int REQUESTOR { get; set; }
    
}