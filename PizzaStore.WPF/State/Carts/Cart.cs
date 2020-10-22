using PizzaStore.Domain.Models.Order;
using PizzaStore.WPF.Models;
using System.Windows.Input;

namespace PizzaStore.WPF.State.Cart
{
    class Cart : ObservableObject, ICart
    {
        private Order _order;

        public Order Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        public ICommand AddItemToCartCommand { get; set; }

        public Cart()
        {
            Order = new Order();
        }
    }
}