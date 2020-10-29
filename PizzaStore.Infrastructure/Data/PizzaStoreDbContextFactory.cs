using Microsoft.EntityFrameworkCore;

namespace PizzaStore.Infrastructure.Data
{
    public class PizzaStoreDbContextFactory
    {
        private readonly string _connectionString;

        public PizzaStoreDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public PizzaStoreDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<PizzaStoreDbContext>();

            options.UseSqlServer(_connectionString);

            return new PizzaStoreDbContext(options.Options);
        }
    }
}