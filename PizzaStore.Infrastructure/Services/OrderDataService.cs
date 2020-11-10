using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.Infrastructure.Data;
using System.Threading.Tasks;

namespace PizzaStore.Infrastructure.Services
{
    public class OrderDataService : GenericDataService<Order>, IOrderDataService
    {
        public OrderDataService(PizzaStoreDbContext context) : base(context) { }

        public override async Task<Order> CreateAsync(Order entity)
        {
            EntityEntry<Order> createdEntity = await _context.Orders.AddAsync(entity);

            await _context.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public override async Task<Order> GetAsync(int id)
        {
            Order order = await _context.Orders
                .Include(q => q.User)
                .Include(q => q.OrderItems)
                .Include(q => q.Address)
                .FirstOrDefaultAsync(q => q.Id == id);

            return order;
        }

        public async Task<Address> ValidateAddress(Address newAddress)
        {
            return await _context.Addresses
                   .FirstOrDefaultAsync(q => q.Street.Equals(newAddress.Street)
                                    && q.Building.Equals(newAddress.Building)
                                    && q.Unit.Equals(newAddress.Unit)) ?? newAddress;
        }
    }
}