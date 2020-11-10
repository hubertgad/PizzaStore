using PizzaStore.Domain.Models.OrderAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Interfaces
{
    public interface IOrderDataService
    {
        Task<IEnumerable<Order>> GetAllAsync();

        Task<Order> GetAsync(int id);

        Task<Order> CreateAsync(Order entity);

        Task<Order> UpdateAsync(int id, Order entity);

        Task<bool> DeleteAsync(int id);

        Task<Address> ValidateAddress(Address newAddress);
    }
}