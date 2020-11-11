using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models;
using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.WPF.Commands;
using PizzaStore.WPF.State.Authenticators;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PizzaStore.WPF.ViewModels
{
    public class CartViewModel : ViewModelBase
    {
        private readonly IOrderDataService _orderService;

        private readonly IEmailService _emailService;

        public User User { get; set; }

        public ObservableCollection<OrderItem> Items { get; set; }

        public decimal TotalPrice => Items.Sum(q => q.Product.Price);

        public string Remarks { get; set; }

        public string Street { get; set; }

        public string Building { get; set; }

        public string Unit { get; set; }

        public ICommand AddItemToCartCommand { get; set; }

        public ICommand RemoveItemFromCartCommand { get; set; }

        public ICommand PlaceOrderCommand { get; set; }

        public CartViewModel(IAuthenticator authenticator, IOrderDataService orderService, IEmailService emailService)
        {
            User = authenticator.CurrentUser;
            _orderService = orderService;
            _emailService = emailService;

            if (User.Orders.LastOrDefault() != null && User.Orders.LastOrDefault().Address != null)
            {
                var address = User.Orders.LastOrDefault().Address;

                Street = address.Street;
                Building = address.Building;
                Unit = address.Unit;
            }

            Items = new ObservableCollection<OrderItem>();

            AddItemToCartCommand = new AddItemToCartCommand(this);
            RemoveItemFromCartCommand = new RemoveItemFromCartCommand(this);
            PlaceOrderCommand = new PlaceOrderCommand(this);
        }

        public void AddItem(OrderItem orderItem)
        {
            Items.Add(orderItem);
            OnPropertyChanged(nameof(TotalPrice));
        }

        public void RemoveItem(OrderItem orderItem)
        {
            var toppingsToRemove = Items.Where(q => q.ParentItem == orderItem).ToList();

            foreach (var topping in toppingsToRemove)
            {
                Items.Remove(topping);
            }
            Items.Remove(orderItem);

            OnPropertyChanged(nameof(TotalPrice));
        }

        public async Task PlaceOrderAsync()
        {
            var address = new Address(Street, Building, Unit);
            address = await _orderService.ValidateAddress(address);

            var order = new Order(Remarks, 0, TotalPrice, User, address, Items);

            try
            {
                await _orderService.CreateAsync(order);

                order = await _orderService.GetAsync(order.Id);
                await _emailService.SendAsync(order);

                MessageBox.Show("Order has been placed! Check your e-mail box to see order's details.");
            }
            catch
            {
                MessageBox.Show("Error: Order cannot be placed!");
            }
        }
    }
}