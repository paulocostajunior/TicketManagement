using AutoMapper;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Domain.Entities;
using MediatR;

namespace TicketManagement.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
{
    private readonly IAsyncRepository<Event> _eventRepository;
    private readonly IMapper _mapper;

    public UpdateEventCommandHandler(IAsyncRepository<Event> eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);

        _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

        await _eventRepository.UpdateAsync(eventToUpdate);
    }
}
