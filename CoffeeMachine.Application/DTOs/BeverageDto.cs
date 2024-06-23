namespace CoffeeMachine.Application.DTOs
{
    public class BeverageDto
    {
        public int BeverageId { get; set; }
        public string? Name { get; set; }
        public Dictionary<string, int>? Ingredients { get; set; }
    }
}