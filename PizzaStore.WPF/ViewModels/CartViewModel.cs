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
        private readonly IDataService<Order> _orderService;
        
        public User User { get; set; }

        public ObservableCollection<OrderItem> Items { get; set; }

        public decimal TotalPrice => Items.Sum(q => q.Price);

        public string Remarks { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string HouseUnitNumber { get; set; }

        public ICommand AddItemToCartCommand { get; set; }

        public ICommand RemoveItemFromCartCommand { get; set; }

        public ICommand PlaceOrderCommand { get; set; }

        public CartViewModel(IAuthenticator authenticator, IDataService<Order> orderService)
        {
            Items = new ObservableCollection<OrderItem>();

            AddItemToCartCommand = new AddItemToCartCommand(this);
            RemoveItemFromCartCommand = new RemoveItemFromCartCommand(this);
            PlaceOrderCommand = new PlaceOrderCommand(this);

            User = authenticator.CurrentUser;
            _orderService = orderService;
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
            var address = new Address(Street, HouseNumber, HouseUnitNumber);
            var order = new Order(Remarks, 0, TotalPrice, address, User, Items);

            await _orderService.CreateAsync(order);

            MessageBox.Show("Order has been placed!" + "\n\n" + order.ToString());
        }
    }
}