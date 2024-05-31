using AutoMapper;
using PizzaShop.Application.DTOs;
using PizzaShop.Application.DTOs.Pizza;
using PizzaShop.Application.DTOs.Size;
using PizzaShop.Domain.Entities;
using System.Net;

namespace PizzaShop.Application.AutoMapper;

internal class PizzaProfile : Profile
{
    public PizzaProfile()
    {
        CreateMap<Pizza, PizzaDto>()
            .ForMember(crtI => crtI.Name, i => i.MapFrom(x => x.Name))
            .ForMember(crtI => crtI.Price, i => i.MapFrom(x => x.Price))
            .ForMember(crtI => crtI.Size, i => i.MapFrom(x => x.Size.Name))
            .ForMember(crtI => crtI.Category, i => i.MapFrom(x => x.Category.Name))
            .ForMember(crtI => crtI.ImageSource, i => i.MapFrom(x => x.ImagePath))
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.Ingredients.Select(i => i.Name).ToArray()))
            .ForMember(crtI => crtI.Description, i => i.MapFrom(x => x.Description));

        CreateMap<CreatePizzaDto, Pizza>()
            .ForMember(crtI => crtI.Name, i => i.MapFrom(x => x.Name))
            .ForMember(crtI => crtI.Price, i => i.MapFrom(x => x.Price))
            .ForMember(crtI => crtI.SizeId, i => i.MapFrom(x => x.SizeId))
            .ForMember(crtI => crtI.CategoryId, i => i.MapFrom(x => x.CategoryId))
            .ForMember(crtI => crtI.Description, i => i.MapFrom(x => x.Description));

        CreateMap<Size, SizeDto>()
            .ForMember(crtI => crtI.SizeName, i => i.MapFrom(x => x.Name));

        CreateMap<Category, CategoryDto>()
            .ForMember(crtI => crtI.CategoryName, i => i.MapFrom(x => x.Name));

        CreateMap<Ingredient, IngredientDto>()
            .ForMember(cerI => cerI.IngredientName, i => i.MapFrom(x => x.Name));

        CreateMap<Order, OrderDto>()
            .ForMember(crtI => crtI.OrderNumber, i => i.MapFrom(x => x.OrderNumber))
            .ForMember(crtI => crtI.TotalPrice, i => i.MapFrom(x => x.Pizza.Price))
            .ForMember(crtI => crtI.Quantity, i => i.MapFrom(x => x.Quantity))
            .ForMember(crtI => crtI.ImageSource, i => i.MapFrom(x => x.Pizza.ImagePath))
            .ForMember(crtI => crtI.PizzaName, i => i.MapFrom(x => x.Pizza.Name))
            .ForMember(crtI => crtI.PizzaId, i => i.MapFrom(x => x.Pizza.Id));


    }
}
