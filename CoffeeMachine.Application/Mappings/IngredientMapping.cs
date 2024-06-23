using AutoMapper;
using CoffeeMachine.Application.DTOs;
using CoffeeMachine.Application.Helpers;
using CoffeeMachine.Domain.Entities;

namespace CoffeeMachine.Application.Mappings
{
    public class IngredientMapping : Profile
    {
        public IngredientMapping()
        {
            CreateMap<Ingredient, IngredientDto>()
                .ForMember(dto => dto.Name, opts => opts.MapFrom(src => src.IngredientType.ToStringFromDescription()));
        }
    }
}