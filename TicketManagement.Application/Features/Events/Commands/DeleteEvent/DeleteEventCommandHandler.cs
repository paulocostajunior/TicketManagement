using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Domain.Entities;
using MediatR;

namespace TicketManagement.Application.Features.Events.Commands.DeleteEvent;

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
{
    private readonly IAsyncRepository<Event> _eventRepository;

    public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var eventToDelete = await _eventRepository.GetByIdAsync(request.EventId);
        
        if (eventToDelete is not null)
        {
            await _eventRepository.DeleteAsync(eventToDelete);
        }
    }
}
