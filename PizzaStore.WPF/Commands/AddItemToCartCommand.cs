using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.WPF.ViewModels;
using System;
using System.Collections;
using System.Windows.Input;

namespace PizzaStore.WPF.Commands
{
    class AddItemToCartCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly CartViewModel _cartViewModel;

        public AddItemToCartCommand(CartViewModel cartViewModel)
        {
            _cartViewModel = cartViewModel;
        }

        public bool CanExecute(object parameter)
        {
            var values = (object[])parameter;
            var quanity = ((MenuPositionViewModel)values[0]).Quantity;

            if (quanity > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async void Execute(object parameter)
        {
            _cartViewModel.StatusMessage = string.Empty;
            _cartViewModel.ErrorMessage = string.Empty;

            var values = (object[])parameter;

            if ((MenuPositionViewModel)values[0] is MenuPositionViewModel menuPosition)
            {
                for (int i = 0; i < menuPosition.Quantity; i++)
                {
                    var orderItem = new OrderItem(menuPosition.Product);
                    _cartViewModel.Items.Add(orderItem);

                    if (values.Length > 1)
                    {
                        foreach (var item in (ICollection)values[1])
                        {
                            var selectedTopping = (Product)item;

                            var orderItemTopping = new OrderItem(selectedTopping, orderItem);

                            _cartViewModel.Items.Add(orderItemTopping);
                        }
                    }
                }
            }

            _cartViewModel.TotalPriceChanged();
        }
    }
}