using MediatR;

namespace TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCategoriesListWithEventsQuery : IRequest<List<CategoryEventListVm>>
{
    public bool IncludeHistory { get; set; }
}
