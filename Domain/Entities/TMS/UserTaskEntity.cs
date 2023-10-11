using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.TMS;

[Table("TASK_USERS")]
public class UserTaskEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public Guid TASK_REF { get; set; }
    public int USER_REF { get; set; }
    public DateTime CREATED_UTC_DATE { get; set; }
}