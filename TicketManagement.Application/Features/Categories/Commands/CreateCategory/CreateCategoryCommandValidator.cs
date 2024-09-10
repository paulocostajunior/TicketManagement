using FluentValidation;

namespace TicketManagement.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage($"{nameof(CreateCategoryCommand.Name)} is required")
            .NotNull()
            .MaximumLength(10).WithMessage($"{nameof(CreateCategoryCommand.Name)} must not exceed 50 characters.");
    }
}
