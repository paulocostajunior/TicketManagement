using System.Runtime.CompilerServices;
using FluentValidation;
using TicketManagement.Application.Contracts.Persistence;

namespace TicketManagement.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    private readonly IEventRepository _eventRepository;
    public CreateEventCommandValidator(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage($"{nameof(CreateEventCommand.Name)} is required")
            .NotNull()
            .MaximumLength(50).WithMessage($"{nameof(CreateEventCommand.Name)} must not exceed 50 characters.");
        
        RuleFor(p => p.Date)
            .NotNull()
            .NotEmpty().WithMessage($"{nameof(CreateEventCommand.Date)} is required")
            .GreaterThan(DateTime.Now);
        
        RuleFor(e => e)
            .MustAsync(EventNameAndDateUnique)
            .WithMessage("An event with the same name and date already exists.");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage($"{nameof(CreateEventCommand.Price)} is required")
            .GreaterThan(0);
    }

    private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken cancellationToken)
    {
        return !await _eventRepository.IsEventNameAndDateUnique(e.Name, e.Date);
    }
}
