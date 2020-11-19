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

            if (parameter is OrderItemViewModel orderItem)
            {
                if (orderItem.ParentItem == null)
                {
                    _cartViewModel.OrderViewModel.Items.Remove(orderItem);
                }
                else
                {
                    _cartViewModel.OrderViewModel.Items.FirstOrDefault(q => q == orderItem.ParentItem).ChildItems.Remove(orderItem);
                }

                _cartViewModel.OrderViewModel.TotalPriceChanged();
            }
        }
    }
}