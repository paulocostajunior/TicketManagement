﻿namespace TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;

public class CategoryEventListVm
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public ICollection<CategoryEventDto> Events { get; set; } = new List<CategoryEventDto>();
}
