using PizzaStore.Domain.Models;
using PizzaStore.Domain.Models.OrderAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Services
{
    public interface IOrderDataService
    {
        Task<IEnumerable<Order>> GetAllAsync(User user = null);

        Task<Order> GetAsync(int id);

        Task<Order> CreateAsync(Order entity);

        Task<Order> UpdateAsync(Order entity);

        Task<bool> DeleteAsync(Order entity);

        Task<Address> CheckIfAddressExists(Address newAddress);
    }
}