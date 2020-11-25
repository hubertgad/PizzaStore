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

            ValidateStreet(order, ref message);
            ValidateBuilding(order, ref message);
            ValidateUnit(order, ref message);
            ValidateZipCode(order, ref message);
            ValidateCity(order, ref message);
            ValidatePhone(order, ref message);
            ValidateName(order, ref message);
            ValidateRemarks(order, ref message);







            if (string.IsNullOrEmpty(message.ToString()) == false) throw new InputNotValidException(message.ToString());
        }

        private void ValidateStreet(Order order, ref StringBuilder message)
        {
            if (order.Address.Street == null || order.Address.Street.Name.Length < 2)
            {
                message.AppendLine("- Street name has be at least 2 characters long.");
            }
            else if (order.Address.Street.Name.Length > 50)
            {
                message.AppendLine("- Street name has be at most 50 character long.");
            }
        }

        private void ValidateBuilding(Order order, ref StringBuilder message)
        {
            if (order.Address.Building == null || order.Address.Building.Length < 1)
            {
                message.AppendLine("- Building has be at least 1 character long.");
            }
            else if (order.Address.Building.Length > 50)
            {
                message.AppendLine("- Building has be at most 50 character long.");
            }
        }

        private void ValidateUnit(Order order, ref StringBuilder message)
        {
            if (order.Address.Unit.Length > 10)
            {
                message.AppendLine("- Building has be at most 10 characters long.");
            }
        }

        private void ValidateZipCode(Order order, ref StringBuilder message)
        {
            Regex regex = new Regex(@"[\d]{2}-?[\d]{3}");

            if (order.Address.ZipCode == null || regex.IsMatch(order.Address.ZipCode.Code) == false)
            {
                message.AppendLine("- Zip code needs to have 5 digits.");
            }
        }

        private void ValidateCity(Order order, ref StringBuilder message)
        {
            if (order.Address.City == null || order.Address.City.Name.Length < 2)
            {
                message.AppendLine("- City name has be at least 2 characters long.");
            }
            else if (order.Address.City.Name.Length > 50)
            {
                message.AppendLine("- City name has be at most 50 character long.");
            }
        }

        private void ValidatePhone(Order order, ref StringBuilder message)
        {
            Regex regex = new Regex(@"[\d]{9}");

            if (order.User.Phone == null || regex.IsMatch(order.User.Phone) == false)
            {
                message.AppendLine("- Phone number needs to have 9 digits.");
            }
        }

        private void ValidateName(Order order, ref StringBuilder message)
        {
            if (order.User.Name == null || order.User.Name.Length < 2)
            {
                message.AppendLine("- Name has to be at least 2 characters long.");
            }
        }

        private void ValidateRemarks(Order order, ref StringBuilder message)
        {
            if (order.Remarks != null && order.Remarks.Length >= 500)
            {
                message.AppendLine("- Remarks has to be at most 500 characters long.");
            }
        }
    }
}