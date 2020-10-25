using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Models.Order;
using PizzaStore.WPF.State.Cart;
using System;
using System.Windows.Input;

namespace PizzaStore.WPF.Commands
{
    class RemoveItemFromCartCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly ICart _cart;

        public RemoveItemFromCartCommand(ICart cart)
        {
            _cart = cart;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is Product product)
            {
                var orderItem2 = new OrderItem(product);
                _cart.RemoveItem(orderItem2);
            }
        }
    }
}