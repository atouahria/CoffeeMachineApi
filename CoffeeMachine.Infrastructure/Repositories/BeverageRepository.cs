using CoffeeMachine.Application.DTOs;
using CoffeeMachine.Application.Helpers;
using CoffeeMachine.Application.Interfaces;
using CoffeeMachine.Domain.Entities;
using CoffeeMachine.Domain.Enums;

namespace CoffeeMachine.Infrastructure.Repositories
{
    public class BeverageRepository : IBeverageRepository
    {
        /* 
                All of this can be replaced by a database by implementing the IBeverageRepository interface and using Entity Framework Core (or any other ORM)
                by creating a class AppDbContext that inherits from DbContext and inject it in this class. Then it will used to retrieve data about beverages and their ingredients.
        
                This is just a simple in-memory repository for the sake of the exercise and to avoid the need of a database connection and setup
        */

        private readonly Dictionary<IngredientType, Ingredient> _ingredients;
        private readonly Dictionary<BeverageType, Beverage> _beverages;
        private const decimal Margin = 0.30m;

        public BeverageRepository()
        {
            _ingredients = new Dictionary<IngredientType, Ingredient>
            {
                [IngredientType.LaitEnPoudre] = new Ingredient { IngredientId = 1, IngredientType = IngredientType.LaitEnPoudre, PricePerDose = 0.10m },
                [IngredientType.Cafe] = new Ingredient { IngredientId = 2, IngredientType = IngredientType.Cafe, PricePerDose = 0.30m },
                [IngredientType.ChocolatEnPoudre] = new Ingredient { IngredientId = 3, IngredientType = IngredientType.ChocolatEnPoudre, PricePerDose = 0.40m },
                [IngredientType.The] = new Ingredient { IngredientId = 4, IngredientType = IngredientType.The, PricePerDose = 0.30m },
                [IngredientType.Eau] = new Ingredient { IngredientId = 5, IngredientType = IngredientType.Eau, PricePerDose = 0.05m }
            };

            _beverages = new Dictionary<BeverageType, Beverage>
            {
                [BeverageType.Espresso] = new Beverage
                {
                    BeverageId = 1,
                    BeverageType = BeverageType.Espresso,
                    Ingredients = new Dictionary<IngredientType, int> { [IngredientType.Eau] = 2, [IngredientType.Cafe] = 1 }
                },
                [BeverageType.Lait] = new Beverage
                {
                    BeverageId = 2,
                    BeverageType = BeverageType.Lait,
                    Ingredients = new Dictionary<IngredientType, int> { [IngredientType.LaitEnPoudre] = 2, [IngredientType.Eau] = 1 }
                },
                [BeverageType.Capuccino] = new Beverage
                {
                    BeverageId = 3,
                    BeverageType = BeverageType.Capuccino,
                    Ingredients = new Dictionary<IngredientType, int> { [IngredientType.LaitEnPoudre] = 2, [IngredientType.Eau] = 1, [IngredientType.Cafe] = 1, [IngredientType.ChocolatEnPoudre] = 1 }
                },
                [BeverageType.ChocolatChaud] = new Beverage
                {
                    BeverageId = 4,
                    BeverageType = BeverageType.ChocolatChaud,
                    Ingredients = new Dictionary<IngredientType, int> { [IngredientType.Eau] = 3, [IngredientType.ChocolatEnPoudre] = 2 }
                },
                [BeverageType.CafeAuLait] = new Beverage
                {
                    BeverageId = 5,
                    BeverageType = BeverageType.CafeAuLait,
                    Ingredients = new Dictionary<IngredientType, int> { [IngredientType.LaitEnPoudre] = 1, [IngredientType.Eau] = 2, [IngredientType.Cafe] = 1 }
                },
                [BeverageType.Mokaccino] = new Beverage
                {
                    BeverageId = 6,
                    BeverageType = BeverageType.Mokaccino,
                    Ingredients = new Dictionary<IngredientType, int> { [IngredientType.LaitEnPoudre] = 1, [IngredientType.Eau] = 2, [IngredientType.Cafe] = 1, [IngredientType.ChocolatEnPoudre] = 2 }
                },
                [BeverageType.The] = new Beverage
                {
                    BeverageId = 7,
                    BeverageType = BeverageType.The,
                    Ingredients = new Dictionary<IngredientType, int> { [IngredientType.Eau] = 2, [IngredientType.The] = 1 }
                }
            };
        }

        public IEnumerable<Beverage> GetBeverages()
        {
            return _beverages.Values;
        }

        public BeverageResponse GetBeverage(int id)
        {
            if (_beverages.TryGetValue((BeverageType)id, out var beverage))
            {
                var price = CalculateBeveragePrice(beverage);

                return new BeverageResponse
                {
                    BeverageId = beverage.BeverageId,
                    Name = beverage.BeverageType.ToStringFromDescription(),
                    Price = price
                };
            }

            return null;
        }

        private decimal CalculateBeveragePrice(Beverage beverage)
        {
            decimal cost = 0;
            foreach (var ingredient in beverage.Ingredients)
            {
                cost += _ingredients[ingredient.Key].PricePerDose * ingredient.Value;
            }

            decimal finalPrice = cost * (1 + Margin);

            return Math.Round(finalPrice, 2);
        }
    }
}