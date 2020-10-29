using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Models.Order;

namespace PizzaStore.Infrastructure.Data
{
    public class PizzaStoreDbContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        
        public DbSet<Tax> Taxes { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public PizzaStoreDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().OwnsOne(q => q.Customer);
            modelBuilder.Entity<Order>().OwnsOne(q => q.Address);

            SeedDatabase(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            var pizzas = new Group(1, "Pizza", false);
            var pizzaToppings = new Group(2, "PizzaTopping", true);
            var mainMeals = new Group(3, "MainMeal", false);
            var mainMealToppings = new Group(4, "MainMealTopping", true);
            var soups = new Group(5, "Soup", false);
            var drinks = new Group(6, "Drink", false);

            var basicTax = new Tax(1, "basicTax", 23);

            modelBuilder.Entity<Group>()
                .HasData(pizzas, pizzaToppings, mainMeals, mainMealToppings, soups, drinks);

            modelBuilder.Entity<Tax>()
                .HasData(basicTax);

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product(1, "Margherita", 20, 1, 1),
                    new Product(2, "Vegetariana", 22, 1, 1),
                    new Product(3, "Tosca", 25, 1, 1),
                    new Product(4, "Venecia", 25, 1, 1),
                    new Product(5, "Double cheese", 2, 1, 2),
                    new Product(6, "Salami", 2, 1, 2),
                    new Product(7, "Ham", 2, 1, 2),
                    new Product(8, "Mushrooms", 2, 1, 2),
                    new Product(9, "Pork chop with chips / rice / potatoes", 30, 1, 3),
                    new Product(10, "Fish and chips", 28, 1, 3),
                    new Product(11, "Hungarian style potato pancake", 27, 1, 3),
                    new Product(12, "Salad bar", 5, 1, 4),
                    new Product(13, "Set of sauces", 6, 1, 4),
                    new Product(14, "Tomato soup", 12, 1, 5),
                    new Product(15, "Chicken soup", 10, 1, 5),
                    new Product(16, "Coffee", 5, 1, 6),
                    new Product(17, "Tea", 5, 1, 6),
                    new Product(18, "Coke", 5, 1, 6)
                );
        }
    }
}