using MediatR;

namespace TicketManagement.Application.Features.Events.Queries.GetEventsDetail;

public class GetEventDetailQuery : IRequest<EventDetailVm>
{
    public Guid Id { get; set; }
}
