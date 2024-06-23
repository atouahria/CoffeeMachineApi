namespace CoffeeMachine.Application.DTOs
{
    public class BeverageResponse
    {
        public int BeverageId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}