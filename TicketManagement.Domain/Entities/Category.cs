﻿using TicketManagement.Domain.Entities.Common;

namespace TicketManagement.Domain.Entities;

public class Category : AuditableEntity
{
	public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public ICollection<Event> Events { get; set; }
}