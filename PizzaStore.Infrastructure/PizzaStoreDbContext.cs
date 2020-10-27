using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Models.Order;

namespace PizzaStore.Infrastructure
{
    class PizzaStoreDbContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        
        public DbSet<Tax> Taxes { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "PizzaStore");

            base.OnConfiguring(optionsBuilder);
        }
    }
}