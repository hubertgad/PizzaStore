using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Models.Order;
using PizzaStore.WPF.State.Cart;
using System;
using System.Windows.Input;

namespace PizzaStore.WPF.Commands
{
    class AddItemToCartCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly ICart _basket;

        public AddItemToCartCommand(ICart basket)
        {
            _basket = basket;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is OrderItem orderItem)
            {
                _basket.Order.OrderItems.Add(orderItem);
            }
            if (parameter is Product product)
            {
                var orderItem2 = new OrderItem(product);
                _basket.Order.OrderItems.Add(orderItem2);
            }
        }
    }
}
