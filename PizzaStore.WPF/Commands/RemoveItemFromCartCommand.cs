using PizzaStore.Domain.Models.OrderAggregate;
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
            if (parameter is OrderItem orderItem)
            {
                _cart.RemoveItem(orderItem);
            }
        }
    }
}