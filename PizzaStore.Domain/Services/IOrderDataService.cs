using PizzaStore.Domain.Models.OrderAggregate;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Services
{
    public interface IOrderDataService : IDataService<Order>
    {
        Task<Address> ValidateAddress(Address newAddress);
    }
}