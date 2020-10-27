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
            var pizzas = new Group("Pizza", false);
            var pizzaToppings = new Group("PizzaTopping", true);
            var mainMeals = new Group("MainMeal", false);
            var mainMealToppings = new Group("MainMealTopping", true);
            var soups = new Group("Soup", false);
            var drinks = new Group("Drink", false);

            var basicTax = new Tax("basicTax", 23);

            return new List<Product>
            {
                new Product("Margherita", 20, basicTax, pizzas),
                new Product("Vegetariana", 22, basicTax, pizzas),
                new Product("Tosca", 25, basicTax, pizzas),
                new Product("Venecia", 25, basicTax, pizzas),
                new Product("Double cheese", 2, basicTax, pizzaToppings),
                new Product("Salami", 2, basicTax, pizzaToppings),
                new Product("Ham", 2, basicTax, pizzaToppings),
                new Product("Mushrooms", 2, basicTax, pizzaToppings),
                new Product("Pork chop with chips / rice / potatoes", 30, basicTax, mainMeals),
                new Product("Fish and chips", 28, basicTax, mainMeals),
                new Product("Hungarian style potato pancake", 27, basicTax, mainMeals),
                new Product("Salad bar", 5, basicTax, mainMealToppings),
                new Product("Set of sauces", 6, basicTax, mainMealToppings),
                new Product("Tomato soup", 12, basicTax, soups),
                new Product("Chicken soup", 10, basicTax, soups),
                new Product("Coffee", 5, basicTax, drinks),
                new Product("Tea", 5, basicTax, drinks),
                new Product("Coke", 5, basicTax, drinks),
            };
        }
    }
}