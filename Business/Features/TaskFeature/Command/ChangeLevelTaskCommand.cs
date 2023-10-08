using Business.Services.TaskServices.Interface;
using Domain.Dto.Task.Input;
using MediatR;

namespace Business.Features.TaskFeature.Command;

public class ChangeLevelTaskCommand : IRequest
{
    public ChangeLevelInputDto input { get; set; } = null!;
}

public class ChangeLevelTaskCommandHandler : IRequestHandler<ChangeLevelTaskCommand>
{
    private readonly ITaskModifyService _taskModifyService;

    public ChangeLevelTaskCommandHandler(ITaskModifyService taskModifyService)
    {
        _taskModifyService = taskModifyService;
    }

    public async Task<Unit> Handle(ChangeLevelTaskCommand request, CancellationToken cancellationToken)
    {
        
        _taskModifyService.SetId(request.input.ident);
        await _taskModifyService.ChangeLevel(request.input.status);
        
        return await Task.FromResult(Unit.Value);
    }
}