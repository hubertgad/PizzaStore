using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Infrastructure.Services
{
    public class OrderDataService : GenericDataService<Order>
    {
        public OrderDataService(PizzaStoreDbContextFactory contextFactory) : base(contextFactory) { }

        public override async Task<Order> CreateAsync(Order entity)
        {
            using var context = _contextFactory.CreateDbContext();

            var orderItems = new List<OrderItem>();

            foreach (var orderItem in entity.OrderItems)
            {
                orderItems.Add(new OrderItem(orderItem.ProductId, orderItem.ParentItem));
            }

            var order = new Order(entity.Remarks,
                    entity.Discount,
                    entity.TotalPrice,
                    entity.Address,
                    entity.UserId,
                    orderItems);

            EntityEntry<Order> createdEntity = await context.Orders.AddAsync(order);
            //EntityEntry<Order> createdEntity = await context.Orders.AddAsync(entity);
            //EntityEntry<Order> createdEntity = context.Orders.Attach(entity);
            //context.Entry(entity).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return createdEntity.Entity;
        }

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