using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.Domain.Services;
using PizzaStore.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Infrastructure.Services
{
    public class OrderDataService : IOrderDataService
    {
        private readonly PizzaStoreDbContext _context;

        public OrderDataService(PizzaStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateAsync(Order entity)
        {
            EntityEntry<Order> createdEntity = await _context.Orders.AddAsync(entity);

            await _context.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task<bool> DeleteAsync(Order entity)
        {
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            List<Order> orders = await _context.Orders.ToListAsync();

            return orders;
        }

        public async Task<Order> GetAsync(int id)
        {
            Order order = await _context.Orders
                .Include(q => q.User)
                .Include(q => q.OrderItems)
                .Include(q => q.Address)
                .FirstOrDefaultAsync(q => q.Id == id);

            return order;
        }

        public async Task<Order> UpdateAsync(Order entity)
        {
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
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