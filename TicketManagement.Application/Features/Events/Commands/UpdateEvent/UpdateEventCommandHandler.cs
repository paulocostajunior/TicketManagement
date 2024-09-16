using AutoMapper;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Domain.Entities;
using MediatR;
using TicketManagement.Application.Exceptions;

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

        if (eventToUpdate is null)
        {
            throw new NotFoundException(nameof(Event), request.EventId);
        }

        var validator = new UpdateEventCommandValidator();
        var validatorResult = await validator.ValidateAsync(request);

        _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

        await _eventRepository.UpdateAsync(eventToUpdate);
    }
}
