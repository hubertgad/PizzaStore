using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Models.Order;

namespace PizzaStore.Infrastructure
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

            base.OnModelCreating(modelBuilder);
        }
    }
}