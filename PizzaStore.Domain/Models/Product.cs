using PizzaStore.Domain.SeedWork;

namespace PizzaStore.Domain.Models
{
    public class Product : Entity
    {
        public string Symbol { get; set; }
        
        public string Name { get; set; }
        
        public decimal Price { get; set; }

        public Type Type { get; set; }
    }

    public enum Type
    {
        Pizza, PizzaAddition, MainMeal, MainMealAddition, Soup, Drink
    }
}