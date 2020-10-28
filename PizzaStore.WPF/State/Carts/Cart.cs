using PizzaStore.Domain.Models.Order;
using PizzaStore.WPF.Commands;
using PizzaStore.WPF.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PizzaStore.WPF.State.Cart
{
    class Cart : ObservableObject, ICart
    {
        public ObservableCollection<OrderItem> Items { get; set; }
        
        public string Remarks { get; set; }

        public decimal TotalPrice => Items.Sum(q => q.Price);
        
        public Customer Customer { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string HouseUnitNumber { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public ICommand AddItemToCartCommand { get; set; }

        public ICommand RemoveItemFromCartCommand { get; set; }

        public ICommand PlaceOrderCommand { get; set; }

        public Cart()
        {
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
            var toppingsToRemove =
                Items.Where(q => q.ParentItemId == orderItem.Id).ToList();

            foreach (var topping in toppingsToRemove)
            {
                Items.Remove(topping);
            }

            Items.Remove(orderItem);

            OnPropertyChanged(nameof(TotalPrice));
        }

        public void PlaceOrder()
        {
            var address = new Address(Street, HouseNumber, HouseUnitNumber);
            var customer = new Customer(Name, Phone, Email);

            var order = new Order(Remarks, 0, TotalPrice, address, customer, Items);

            MessageBox.Show(order.ToString());
        }
    }
}