﻿using AutoMapper;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Domain.Entities;
using MediatR;
using TicketManagement.Application.Contracts.Infrastructure;
using TicketManagement.Application.Models.Mail;
using Microsoft.Extensions.Logging;

namespace TicketManagement.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly ILogger<CreateEventCommandHandler> _logger;

    public CreateEventCommandHandler(
        IEventRepository eventRepository,
        IMapper mapper,
        IEmailService emailService,
        ILogger<CreateEventCommandHandler> logger)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _emailService = emailService;
        _logger = logger;
    }

    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var @event = _mapper.Map<Event>(request);

        var validator = new CreateEventCommandValidator(_eventRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
        {
            throw new Exceptions.ValidationException(validationResult);
        }

        @event = await _eventRepository.AddAsync(@event);
        
        var email = new Email()
        {
            To = "test@cleanarch.com",
            Body = "This is an event test email",
            Subject = "Clean Architecture"
        };

        try 
        {
            await _emailService.SendEmail(email);
        }
        catch (Exception ex)
        {
            //dont stop the app if it errors out
            _logger.LogError($"Mailing about event {@event.EventId} failed due to an error with the mail service: {ex.Message}");
        }

        return @event.EventId;
    }
}
