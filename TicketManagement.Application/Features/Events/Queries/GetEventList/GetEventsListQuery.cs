﻿using MediatR;

namespace TicketManagement.Application.Features.Events.Queries.GetEventList;

public class GetEventsListQuery : IRequest<List<EventListVm>>
{
}