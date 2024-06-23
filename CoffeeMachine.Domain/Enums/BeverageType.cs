using System.ComponentModel;

namespace CoffeeMachine.Domain.Enums
{
    public enum BeverageType
    {
        [Description("Espresso")]
        Espresso = 1,
        [Description("Lait")]
        Lait = 2,
        [Description("Capuccino")]
        Capuccino = 3,
        [Description("Chocolat chaud")]
        ChocolatChaud = 4,
        [Description("Café au lait")]
        CafeAuLait = 5,
        [Description("Mokaccino")]
        Mokaccino = 6,
        [Description("Thé")]
        The = 7
    }
}