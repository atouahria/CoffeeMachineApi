using CoffeeMachine.Domain.Enums;
using CoffeeMachine.Infrastructure.Repositories;

namespace CoffeeMachine.Infrastructure.Tests
{
    public class BeverageRepositoryTest
    {
        [Fact]
        public void GetBeverages_ShouldReturnAllBeverages()
        {
            // Arrange
            var repository = new BeverageRepository();

            // Act
            var beverages = repository.GetBeverages();

            // Assert
            Assert.NotNull(beverages);
            Assert.Equal(7, beverages.Count());
        }

        [Theory]
        [InlineData(1, "Espresso")]
        [InlineData(2, "Lait")]
        [InlineData(3, "Capuccino")]
        [InlineData(4, "Chocolat chaud")]
        [InlineData(5, "Café au lait")]
        [InlineData(6, "Mokaccino")]
        [InlineData(7, "Thé")]
        [InlineData(10, null)]
        public void GetBeverage_ShouldReturnCorrectBeverage(int id, string? expectedBeverageType)
        {
            // Arrange
            var repository = new BeverageRepository();

            // Act
            var beverage = repository.GetBeverage(id);

            // Assert
            Assert.Equal(expectedBeverageType, beverage?.Name);
        }

        [Theory]
        [InlineData(1, 0.52)]
        [InlineData(2, 0.32)]
        [InlineData(3, 1.24)]
        [InlineData(4, 1.24)]
        [InlineData(5, 0.65)]
        [InlineData(6, 1.69)]
        [InlineData(7, 0.52)]
        public void GetBeverage_ShouldReturnCorrectPrice(int id, decimal expectedPrice)
        {
            // Arrange
            var repository = new BeverageRepository();

            // Act
            var beveragePrice = repository.GetBeverage(id);

            // Assert
            Assert.NotNull(beveragePrice);
            Assert.Equal(expectedPrice, beveragePrice.Price);
        }

        [Fact]
        public void GetBeverage_ShouldReturnNullObjectWhenIdIsNotCorrect()
        {
            // Arrange
            var repository = new BeverageRepository();

            // Act
            var beveragePriceResponse = repository.GetBeverage(10);

            // Assert
            Assert.Null(beveragePriceResponse);
        }
    }
}