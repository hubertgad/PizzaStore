using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models.Menu;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Infrastructure.Services
{
    public class HardCodedProductDataService : IDataService<Product>
    {
        public async Task<IEnumerable<Product>> GetAll()
        {
            var pizzas = new Group { Id = 1, Name = "Pizza", IsTopping = false };
            var pizzaToppings = new Group { Id = 2, Name = "PizzaTopping", IsTopping = true };
            var basicTax = new Tax("basicTax", 23);

            return new List<Product>
            {
                new Product("Margaritta", 20, basicTax, pizzas),
                new Product("Vegetariana", 22, basicTax, pizzas),
                new Product("Tosca", 25, basicTax, pizzas),
                new Product("Venecia", 25, basicTax, pizzas),
                new Product("Double cheese", 2, basicTax, pizzaToppings),
                new Product("Salami", 2, basicTax, pizzaToppings),
                new Product("Ham", 2, basicTax, pizzaToppings),
                new Product("Mushrooms", 2, basicTax, pizzaToppings)
            };
        }
    }
}