using Domain.DTO.Task.Output;
using Domain.Entities.TMS;
using MediatR;

namespace Business.Features.TaskFeature.Query;

public class TaskQuery : IRequest<List<TaskOutputDto>>
{
    
}

public class TaskQueryHandler : IRequestHandler<TaskQuery, List<TaskOutputDto>>
{
    
    
    
    public async Task<List<TaskOutputDto>> Handle(TaskQuery request, CancellationToken cancellationToken)
    {
        return new List<TaskOutputDto>();
    }
}