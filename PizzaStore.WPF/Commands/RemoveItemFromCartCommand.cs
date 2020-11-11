using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.WPF.ViewModels;
using System;
using System.Linq;
using System.Windows.Input;

namespace PizzaStore.WPF.Commands
{
    class RemoveItemFromCartCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly CartViewModel _cartViewModel;

        public RemoveItemFromCartCommand(CartViewModel cartViewModel)
        {
            _cartViewModel = cartViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _cartViewModel.StatusMessage = string.Empty;
            _cartViewModel.ErrorMessage = string.Empty;

            if (parameter is OrderItem orderItem)
            {
                var toppingsToRemove = _cartViewModel.Items.Where(q => q.ParentItem == orderItem).ToList();

                foreach (var topping in toppingsToRemove)
                {
                    _cartViewModel.Items.Remove(topping);
                }
                _cartViewModel.Items.Remove(orderItem);

                _cartViewModel.TotalPriceChanged();
            }
        }
    }
}