using PizzaStore.Domain.Models.Order;
using System.Windows.Input;

namespace PizzaStore.WPF.State.Basket
{
    public interface IBasket
    {
        public Order Order { get; }

        public ICommand AddItemToBasketCommand { get; set; }
    }
}