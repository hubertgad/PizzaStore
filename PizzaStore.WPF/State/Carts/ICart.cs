using PizzaStore.Domain.Models.Order;
using System.Windows.Input;

namespace PizzaStore.WPF.State.Cart
{
    public interface ICart
    {
        public Order Order { get; }

        public ICommand AddItemToCartCommand { get; set; }
    }
}