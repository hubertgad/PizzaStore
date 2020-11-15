using PizzaStore.Domain.Models.Menu;
using PizzaStore.Infrastructure.Data;
using System.Linq;

namespace PizzaStore.Infrastructure.Services
{
    public class DataSeeder
    {
        private readonly PizzaStoreDbContext _context;

        public DataSeeder(PizzaStoreDbContext context)
        {
            _context = context;

            SeedDatabase();
        }

        public void SeedDatabase()
        {
            if (_context.Groups.Count() != 0) return;

            var pizzas = new Group("Pizzas", false);
            var pizzaToppings = new Group("Pizzas", true);
            var mainMeals = new Group("MainMeals", false);
            var mainMealToppings = new Group("MainMeals", true);
            var soups = new Group("Soups", false);
            var drinks = new Group("Drinks", false);

            _context.Products.AddRange(
                    new Product("Margherita", 20, pizzas, 1),
                    new Product("Vegetariana", 22, pizzas, 2),
                    new Product("Tosca", 25, pizzas, 3),
                    new Product("Venecia", 25, pizzas, 4),
                    new Product("Double cheese", 2, pizzaToppings, 5),
                    new Product("Salami", 2, pizzaToppings, 6),
                    new Product("Ham", 2, pizzaToppings, 7),
                    new Product("Mushrooms", 2, pizzaToppings, 8),
                    new Product("Pork chop with chips / rice / potatoes", 30, mainMeals, 9),
                    new Product("Fish and chips", 28, mainMeals, 10),
                    new Product("Hungarian style potato pancake", 27, mainMeals, 11),
                    new Product("Salad bar", 5, mainMealToppings, 12),
                    new Product("Set of sauces", 6, mainMealToppings, 13),
                    new Product("Tomato soup", 12, soups, 14),
                    new Product("Chicken soup", 10, soups, 15),
                    new Product("Coffee", 5, drinks, 16),
                    new Product("Tea", 5, drinks, 17),
                    new Product("Coke", 5, drinks, 18)
                );

            _context.SaveChanges();
        }
    }
}