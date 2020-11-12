using PizzaStore.Domain.Models.OrderAggregate;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Services.OrderServices
{
    public interface IPlaceOrderService
    {
        public Task PlaceOrder(Order order);
    }
}