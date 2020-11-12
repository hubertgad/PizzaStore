using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.Domain.Services.EmailServices;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Services.OrderServices
{
    public class PlaceOrderService : IPlaceOrderService
    {
        private readonly IOrderDataService _orderDataService;
        private readonly IEmailService _emailService;

        public PlaceOrderService(IOrderDataService orderDataService, IEmailService emailService)
        {
            _orderDataService = orderDataService;
            _emailService = emailService;
        }

        public async Task PlaceOrder(Order order)
        {
            order.Address = await _orderDataService.ValidateAddress(order.Address);
            order = await _orderDataService.CreateAsync(order);

            await _emailService.SendAsync(order);
        }
    }
}