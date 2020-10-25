using PizzaStore.WPF.State.Cart;
using System;
using System.Windows.Input;

namespace PizzaStore.WPF.Commands
{
    class PlaceOrderCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly ICart _cart;

        public PlaceOrderCommand(ICart cart)
        {
            _cart = cart;
        }

        public bool CanExecute(object parameter)
        {
            if (_cart.Items.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Execute(object parameter)
        {
            _cart.PlaceOrder();
        }
    }
}