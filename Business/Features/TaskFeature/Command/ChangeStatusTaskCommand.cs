using Business.Services.TaskServices.Interface;
using Domain.Dto.Task.Input;
using MediatR;

namespace Business.Features.TaskFeature.Command;

public class ChangeStatusTaskCommand : IRequest
{
    public ChangeStatusInputDto input { get; set; } = null!;
}

public class ChangeStatusTaskCommandHandler : IRequestHandler<ChangeStatusTaskCommand>
{
    private readonly ITaskModifyService _taskModifyService;

    public ChangeStatusTaskCommandHandler(ITaskModifyService taskModifyService)
    {
        _taskModifyService = taskModifyService;
    }

    public async Task<Unit> Handle(ChangeStatusTaskCommand request, CancellationToken cancellationToken)
    {
        
        _taskModifyService.SetId(request.input.ident);
        await _taskModifyService.MoveStatus(request.input.status);
        
        return await Task.FromResult(Unit.Value);
    }
}