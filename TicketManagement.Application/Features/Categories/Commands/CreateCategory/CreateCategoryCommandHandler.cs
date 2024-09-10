using AutoMapper;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Domain.Entities;
using MediatR;

namespace TicketManagement.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    private readonly IAsyncRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var createCategoryCommandResponse = new CreateCategoryCommandResponse();
        
        var validator = new CreateCategoryCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
        {
            createCategoryCommandResponse.Success = false;
            createCategoryCommandResponse.ValidationErrors = new();
            foreach (var errors in validationResult.Errors)
            {
                createCategoryCommandResponse.ValidationErrors.Add(errors.ErrorMessage);
            }
        }

        if (createCategoryCommandResponse.Success)
        {
            var category = _mapper.Map<Category>(request);
            category = await _categoryRepository.AddAsync(category);
        
            createCategoryCommandResponse.Category = _mapper.Map<CreateCategoryDto>(category);
        }
        
        return createCategoryCommandResponse;
    }
}
