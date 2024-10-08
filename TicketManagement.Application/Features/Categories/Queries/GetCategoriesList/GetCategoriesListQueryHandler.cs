﻿using AutoMapper;
using TicketManagement.Application.Contracts.Persistence;
using MediatR;

namespace TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCategoriesListQueryHandler: IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoriesListQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
    {
        var allCategories = (await _categoryRepository.ListAllAsync()).OrderBy(c => c.Name);
        
        return _mapper.Map<List<CategoryListVm>>(allCategories);
    }
}
