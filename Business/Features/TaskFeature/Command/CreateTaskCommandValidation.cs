using FluentValidation;

namespace Business.Features.TaskFeature.Command;

public class CreateTaskCommandValidation : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidation()
    {
        _ = RuleFor(x => x.input.task_title)
            .NotEmpty().WithMessage("Title is required")
            .NotNull().WithMessage("Title is required")
            .MaximumLength(150).WithMessage("Maximum of 150 characters only");

        _ = RuleFor(x => x.input.task_status)
            .NotNull().WithMessage("Status is required");
        
        _ = RuleFor(x => x.input.task_level)
            .NotNull().WithMessage("Level is required");

    }
}