using System.ComponentModel;

namespace CoffeeMachine.Domain.Enums
{
    public enum IngredientType
    {
        [Description("Lait en poudre")]
        LaitEnPoudre,
        [Description("Café")]
        Cafe,
        [Description("Chocolat en poudre")]
        ChocolatEnPoudre,
        [Description("Thé")]
        The,
        [Description("Eau")]
        Eau
    }
}