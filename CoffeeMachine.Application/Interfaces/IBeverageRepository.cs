using CoffeeMachine.Application.DTOs;
using CoffeeMachine.Domain.Entities;

namespace CoffeeMachine.Application.Interfaces
{
    public interface IBeverageRepository
    {
        IEnumerable<Beverage> GetBeverages();

        BeverageResponse GetBeverage(int id);
    }
}