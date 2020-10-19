namespace PizzaStore.Domain.SeedWork
{
    public class Product : Entity
    {
        public string Symbol { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}