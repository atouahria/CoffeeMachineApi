using AutoMapper;
using CoffeeMachine.Application.DTOs;
using CoffeeMachine.Application.Helpers;
using CoffeeMachine.Domain.Entities;
using CoffeeMachine.Domain.Enums;

namespace CoffeeMachine.Application.Mappings
{
    public class BeverageMapping : Profile
    {
        public BeverageMapping()
        {
            CreateMap<Beverage, BeverageDto>()
                .ForMember(dto => dto.Name, opts => opts.MapFrom(src => src.BeverageType.ToStringFromDescription()));

            CreateMap<KeyValuePair<IngredientType, int>, KeyValuePair<string, int>>()
                .ConvertUsing(src => new KeyValuePair<string, int>(src.Key.ToStringFromDescription(), src.Value));
        }
    }
}