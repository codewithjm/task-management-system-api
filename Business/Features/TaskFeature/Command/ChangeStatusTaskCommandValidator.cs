using FluentValidation;

namespace Business.Features.TaskFeature.Command;

public class ChangeStatusTaskCommandValidator : AbstractValidator<ChangeStatusTaskCommand>
{
    public ChangeStatusTaskCommandValidator()
    {
        _ = RuleFor(x => x.input.ident)
            .NotEqual(Guid.Empty).WithMessage("Task id is required")
            .NotNull().WithMessage("Task id is required");

        _ = RuleFor(x => x.input.status)
            .NotNull().WithMessage("Task status is required");
    }
}