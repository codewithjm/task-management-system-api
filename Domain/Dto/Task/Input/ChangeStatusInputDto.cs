namespace Domain.Dto.Task.Input;

public class ChangeStatusInputDto
{
    public Guid ident { get; set; }
    public int status { get; set; }
}