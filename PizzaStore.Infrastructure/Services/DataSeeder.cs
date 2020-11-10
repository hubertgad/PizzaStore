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

            var pizzas = new Group("Pizza", false);
            var pizzaToppings = new Group("PizzaTopping", true);
            var mainMeals = new Group("MainMeal", false);
            var mainMealToppings = new Group("MainMealTopping", true);
            var soups = new Group("Soup", false);
            var drinks = new Group("Drink", false);

            _context.Products.AddRange(
                    new Product("Margherita", 20, pizzas),
                    new Product("Vegetariana", 22, pizzas),
                    new Product("Tosca", 25, pizzas),
                    new Product("Venecia", 25, pizzas),
                    new Product("Double cheese", 2, pizzaToppings),
                    new Product("Salami", 2, pizzaToppings),
                    new Product("Ham", 2, pizzaToppings),
                    new Product("Mushrooms", 2, pizzaToppings),
                    new Product("Pork chop with chips / rice / potatoes", 30, mainMeals),
                    new Product("Fish and chips", 28, mainMeals),
                    new Product("Hungarian style potato pancake", 27, mainMeals),
                    new Product("Salad bar", 5, mainMealToppings),
                    new Product("Set of sauces", 6, mainMealToppings),
                    new Product("Tomato soup", 12, soups),
                    new Product("Chicken soup", 10, soups),
                    new Product("Coffee", 5, drinks),
                    new Product("Tea", 5, drinks),
                    new Product("Coke", 5, drinks)
                );

            _context.SaveChanges();
        }
    }
}