using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Models;
using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Models.OrderAggregate;

namespace PizzaStore.Infrastructure.Data
{
    public class PizzaStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<ZipCode> ZipCodes { get; set; }

        public DbSet<Street> Streets { get; set; }

        public DbSet<Order> Orders { get; set; }

        public PizzaStoreDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(q => q.Email)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(q => q.Name)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(q => q.Phone)
                .HasMaxLength(15)
                .IsRequired(false);
            modelBuilder.Entity<User>()
                .Property(q => q.PasswordHash)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Group>()
                .Property(q => q.Name).IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Product>()
                .Property(q => q.Name)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(q => q.Price)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
            modelBuilder.Entity<Product>()
                .HasOne(q => q.Group)
                .WithMany(q => q.Products)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(q => q.TotalPrice)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
            modelBuilder.Entity<Order>()
                .Property(q => q.Discount)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
            modelBuilder.Entity<Order>()
                .Property(q => q.Remarks)
                .HasMaxLength(500)
                .IsRequired(false);
            modelBuilder.Entity<Order>()
                .HasOne(q => q.Address)
                .WithMany()
                .IsRequired();
            modelBuilder.Entity<Order>()
                .HasOne(q => q.User)
                .WithMany(q => q.Orders)
                .IsRequired();
            modelBuilder.Entity<Order>()
                .HasMany(q => q.OrderItems)
                .WithOne(q => q.Order)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(q => q.Building)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Address>()
                .Property(q => q.Unit)
                .HasMaxLength(10)
                .IsRequired();
            modelBuilder.Entity<Address>()
                .HasOne(q => q.City)
                .WithMany()
                .IsRequired();
            modelBuilder.Entity<Address>()
                .HasOne(q => q.ZipCode)
                .WithMany()
                .IsRequired();
            modelBuilder.Entity<Address>()
                .HasOne(q => q.Street)
                .WithMany()
                .IsRequired();

            modelBuilder.Entity<City>()
                .Property(q => q.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<ZipCode>()
                .Property(q => q.Code)
                .HasMaxLength(10);

            modelBuilder.Entity<Street>()
                .Property(q => q.Name)
                .HasMaxLength(50);

            base.OnModelCreating(modelBuilder);
        }
    }
}