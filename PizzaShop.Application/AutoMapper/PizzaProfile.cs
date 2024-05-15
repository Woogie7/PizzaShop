using AutoMapper;
using PizzaShop.Application.DTOs;
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
            .ForMember(crtI => crtI.Ingredients, i => i.MapFrom(x => x.Ingredients))
            .ForMember(crtI => crtI.Description, i => i.MapFrom(x => x.Description));

        //CreateMap<PizzaDto, Pizza>()
        //    .ForMember(crtI => crtI.id, i => i.MapFrom(x => x.Id))
        //    .ForMember(crtI => crtI.Amount, i => i.MapFrom(x => x.Amount))
        //    .ForMember(crtI => crtI.Currency, i => i.MapFrom(x => x.Currency.Id))
        //    .ForMember(crtI => crtI.CategoryIncome, i => i.MapFrom(x => x.Category.Id))
        //    .ForMember(crtI => crtI.Date, i => i.MapFrom(x => x.Date));


    }
}
