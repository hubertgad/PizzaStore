using PizzaStore.Domain.Exceptions;
using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.Domain.Services.EmailServices;
using System.Text;
using System.Text.RegularExpressions;
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
            ValidateOrder(order);

            order.Address = await _orderDataService.CheckIfAddressExists(order.Address);

            order = await _orderDataService.CreateAsync(order);

            await _emailService.SendAsync(order);
        }

        private void ValidateOrder(Order order)
        {
            StringBuilder message = new StringBuilder();

            if (order.Address.Street == null || order.Address.Street.Name.Length < 2) message.AppendLine("- Street name has be at least 2 characters long.");
            else if (order.Address.Street.Name.Length > 50) message.AppendLine("- Street name has be at most 50 character long.");

            if (order.Address.Building == null || order.Address.Building.Length < 1) message.AppendLine("- Building has be at least 1 character long.");
            else if (order.Address.Building.Length > 50) message.AppendLine("- Building has be at most 50 character long.");

            if (order.Address.Unit.Length > 10) message.AppendLine("- Building has be at most 10 characters long.");

            if (order.Address.ZipCode == null || Regex.IsMatch(order.Address.ZipCode.Code, @"[\d]{2}-?[\d]{3}") == false) message.AppendLine("- Zip code needs to have 5 digits.");

            if (order.Address.City == null || order.Address.City.Name.Length < 2) message.AppendLine("- City name has be at least 2 characters long.");
            else if (order.Address.City.Name.Length > 50) message.AppendLine("- City name has be at most 50 character long.");

            if (order.User.Phone == null || Regex.IsMatch(order.User.Phone, @"[\d]{9}") == false) message.AppendLine("- Phone number needs to have 9 digits.");

            if (order.User.Name == null || order.User.Name.Length < 2) message.AppendLine("- Name has to be at least 2 characters long.");

            if (order.Remarks != null && order.Remarks.Length >= 500) message.AppendLine("- Remarks has to be at most 500 characters long.");

            if (string.IsNullOrEmpty(message.ToString()) == false) throw new InputNotValidException(message.ToString());
        }
    }
}