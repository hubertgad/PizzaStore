using PizzaStore.Domain.Models.Order;
using PizzaStore.WPF.Models;
using System.Windows.Input;

namespace PizzaStore.WPF.State.Basket
{
    class Basket : ObservableObject, IBasket
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

        public ICommand AddItemToBasketCommand { get; set; }

        public Basket()
        {
            Order = new Order();
        }
    }
}