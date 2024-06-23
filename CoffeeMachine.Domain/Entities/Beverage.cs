using CoffeeMachine.Domain.Enums;

namespace CoffeeMachine.Domain.Entities
{
    public class Beverage
    {
        public int BeverageId { get; set; }
        public BeverageType BeverageType { get; set; }
        public Dictionary<IngredientType, int> Ingredients { get; set; } = new Dictionary<IngredientType, int>();
    }
}