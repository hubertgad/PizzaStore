using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.Infrastructure.Data;
using System.Threading.Tasks;

namespace PizzaStore.Infrastructure.Services
{
    public class OrderDataService : GenericDataService<Order>
    {
        public OrderDataService(PizzaStoreDbContextFactory contextFactory) : base(contextFactory) { }

        public override async Task<Order> GetAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            Order order = await context.Orders
                .Include(q => q.User)
                .Include(q => q.OrderItems)
                .FirstOrDefaultAsync(q => q.Id == id);

            return order;
        }
    }
}