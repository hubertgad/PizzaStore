using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Models;
using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Models.OrderAggregate;
using System.Collections.Concurrent;

namespace PizzaStore.Infrastructure.Data
{
    public class PizzaStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public DbSet<Group> Groups { get; set; }
        
        //public DbSet<Tax> Taxes { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public PizzaStoreDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            //var basicTax = new Tax(1, "basicTax", 23);

            modelBuilder.Entity<Group>()
                .HasData(pizzas, pizzaToppings, mainMeals, mainMealToppings, soups, drinks);

            //modelBuilder.Entity<Tax>()
            //    .HasData(basicTax);

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product(1,  "Margherita",                             20, /*basicTax,*/ pizzas),
                    new Product(2,  "Vegetariana",                            22, /*basicTax,*/ pizzas),
                    new Product(3,  "Tosca",                                  25, /*basicTax,*/ pizzas),
                    new Product(4,  "Venecia",                                25, /*basicTax,*/ pizzas),
                    new Product(5,  "Double cheese",                          2,  /*basicTax,*/ pizzaToppings),
                    new Product(6,  "Salami",                                 2,  /*basicTax,*/ pizzaToppings),
                    new Product(7,  "Ham",                                    2,  /*basicTax,*/ pizzaToppings),
                    new Product(8,  "Mushrooms",                              2,  /*basicTax,*/ pizzaToppings),
                    new Product(9,  "Pork chop with chips / rice / potatoes", 30, /*basicTax,*/ mainMeals),
                    new Product(10, "Fish and chips",                         28, /*basicTax,*/ mainMeals),
                    new Product(11, "Hungarian style potato pancake",         27, /*basicTax,*/ mainMeals),
                    new Product(12, "Salad bar",                              5,  /*basicTax,*/ mainMealToppings),
                    new Product(13, "Set of sauces",                          6,  /*basicTax,*/ mainMealToppings),
                    new Product(14, "Tomato soup",                            12, /*basicTax,*/ soups),
                    new Product(15, "Chicken soup",                           10, /*basicTax,*/ soups),
                    new Product(16, "Coffee",                                 5,  /*basicTax,*/ drinks),
                    new Product(17, "Tea",                                    5,  /*basicTax,*/ drinks),
                    new Product(18, "Coke",                                   5,  /*basicTax,*/ drinks)
                );
        }
    }
}