using AutoMapper;
using TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using TicketManagement.Application.Features.Events.Commands.CreateEvent;
using TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using TicketManagement.Application.Features.Events.Queries.GetEventList;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Event, EventListVm>().ReverseMap();
        CreateMap<Event, EventDetailVm>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        
        CreateMap<Category, CategoryEventDto>();
        CreateMap<Category, CategoryEventListVm>();

        CreateMap<Event, CreateEventCommandHandler>().ReverseMap();

        CreateMap<Category, CategoryDto>();
        CreateMap<Category, CategoryListVm>();
        CreateMap<Category, CategoryEventListVm>();
        CreateMap<Category, CreateCategoryCommand>();
        CreateMap<Category, CreateCategoryDto>();
    }
}