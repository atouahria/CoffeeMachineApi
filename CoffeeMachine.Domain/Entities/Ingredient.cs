using CoffeeMachine.Domain.Enums;

namespace CoffeeMachine.Domain.Entities
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public IngredientType IngredientType { get; set; }
        public decimal PricePerDose { get; set; }
    }
}