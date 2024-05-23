using AutoMapper;
using PizzaShop.Application.DTOs;
using PizzaShop.Application.DTOs.Size;
using PizzaShop.Domain.Entities;

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

        CreateMap<Size, SizeDto>()
            .ForMember(crtI => crtI.SizeName, i => i.MapFrom(x => x.Name));


    }
}
