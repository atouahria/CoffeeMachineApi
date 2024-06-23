using CoffeeMachine.Domain.Enums;
using System.ComponentModel;

namespace CoffeeMachine.Application.Helpers
{
    public static class MyEnumExtensions
    {
        public static string ToStringFromDescription(this BeverageType value)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])value
               .GetType()
               .GetField(value.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static string ToStringFromDescription(this IngredientType value)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])value
               .GetType()
               .GetField(value.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}