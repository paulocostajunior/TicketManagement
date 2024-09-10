using AutoMapper;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using MediatR;

namespace TicketManagement.Application;

public class GetCategoriesListWithEventsQueryHandler : IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListVm>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public async Task<List<CategoryEventListVm>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
    {
        var allCategoriesListWithEvent = await _categoryRepository
            .GetCategoriesWithEvents(request.IncludeHistory);

        return _mapper.Map<List<CategoryEventListVm>>(allCategoriesListWithEvent);
    }
}
