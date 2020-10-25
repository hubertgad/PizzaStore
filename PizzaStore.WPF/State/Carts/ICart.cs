using PizzaStore.Domain.Models.Order;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PizzaStore.WPF.State.Cart
{
    public interface ICart
    {
        public ICommand AddItemToCartCommand { get; set; }

        public ICommand RemoveItemFromCartCommand { get; set; }

        public ICommand PlaceOrderCommand { get; set; }

        public ObservableCollection<OrderItem> Items { get; set; }

        public void AddItem(OrderItem orderItem);

        public void RemoveItem(OrderItem orderItem);
        
        public void PlaceOrder();
    }
}