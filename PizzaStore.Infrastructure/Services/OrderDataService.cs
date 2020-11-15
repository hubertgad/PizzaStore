using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PizzaStore.Domain.Models;
using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.Domain.Services;
using PizzaStore.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ICollection<Order>> GetAllAsync(User user = null)
        {
            IQueryable<Order> orders = _context.Orders;

            if (user != null)
            {
                orders = orders.Where(q => q.User == user);
            }

            var orderList = await orders
                .Include(q => q.User)
                .Include(q => q.Address)
                .OrderByDescending(q => q.Placed)
                .ToListAsync();

            foreach (var order in orderList)
            {
                order.OrderItems = await _context
                                        .OrderItems
                                        .Where(q => q.Order == order && q.ParentItem == null)
                                        .Include(q => q.ChildItems)
                                        .ToListAsync();
            }

            return orderList;
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

        public async Task<Address> CheckIfAddressExists(Address newAddress)
        {
            var existingCity = _context.Cities.FirstOrDefault(q => q.Name == newAddress.City.Name);
            var existingZipCode = _context.ZipCodes.FirstOrDefault(q => q.Code == newAddress.ZipCode.Code);
            var existingStreet = _context.Streets.FirstOrDefault(q => q.Name == newAddress.Street.Name);

            if (existingCity != null) newAddress.City = existingCity;
            if (existingZipCode != null) newAddress.ZipCode = existingZipCode;
            if (existingStreet != null) newAddress.Street = existingStreet;

            if (existingCity != null && existingZipCode != null && existingStreet != null)
            {
                var existingAddress = await _context.Addresses
                       .FirstOrDefaultAsync(q => q.Street.Name.Equals(newAddress.Street.Name)
                                        && q.Building.Equals(newAddress.Building)
                                        && q.Unit.Equals(newAddress.Unit)
                                        && q.ZipCode.Code.Equals(newAddress.ZipCode.Code)
                                        && q.City.Name.Equals(newAddress.City.Name));

                if (existingAddress != null) return existingAddress;
            }
            
            return newAddress;
        }
    }
}