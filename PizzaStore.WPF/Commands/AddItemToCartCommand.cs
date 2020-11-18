using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.WPF.ViewModels;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PizzaStore.WPF.Commands
{
    class AddItemToCartCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly CartViewModel _cartViewModel;

        private readonly MenuViewModel _menuViewModel;

        public AddItemToCartCommand(CartViewModel cartViewModel, MenuViewModel menuViewModel)
        {
            _cartViewModel = cartViewModel;
            _menuViewModel = menuViewModel;
        }

        public bool CanExecute(object parameter)
        {
            var values = (object[])parameter;
            var quanity = ((MenuPositionViewModel)values[0]).Quantity;

            if (int.TryParse(quanity, out int intQuantity) && intQuantity > 0)
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

            if ((MenuPositionViewModel)values[0] is MenuPositionViewModel menuPosition
                && int.TryParse(menuPosition.Quantity, out int quantity) 
                && quantity > 0)
            {
                for (int i = 0; i < quantity; i++)
                {
                    if (values.Length > 1)
                    {
                        var toppings = new ObservableCollection<OrderItemViewModel>();

                        var orderItem = new OrderItemViewModel(menuPosition.Product, null, toppings);

                        foreach (var item in (ICollection)values[1])
                        {
                            var selectedTopping = (Product)item;

                            //_cartViewModel.Items.Add(new OrderItem(selectedTopping, orderItem));
                            toppings.Add(new OrderItemViewModel(selectedTopping, orderItem));
                        }

                        _cartViewModel.OrderViewModel.Items.Add(orderItem);
                    }
                    else
                    {
                        _cartViewModel.OrderViewModel.Items.Add(new OrderItemViewModel(menuPosition.Product));
                    }
                }
            }
            _cartViewModel.OrderViewModel.TotalPriceChanged();
        }

        //public async void Execute(object parameter)
        //{
        //    _cartViewModel.StatusMessage = string.Empty;
        //    _cartViewModel.ErrorMessage = string.Empty;

        //    var values = (object[])parameter;

        //    if ((MenuPositionViewModel)values[0] is MenuPositionViewModel menuPosition
        //        && int.TryParse(menuPosition.Quantity, out int quantity) 
        //        && quantity > 0)
        //    {
        //        for (int i = 0; i < quantity; i++)
        //        {
        //            if (values.Length > 1)
        //            {
        //                ObservableCollection<OrderItem> toppings = new ObservableCollection<OrderItem>();

        //                var orderItem = new OrderItem(menuPosition.Product, null, toppings);

        //                foreach (var item in (ICollection)values[1])
        //                {
        //                    var selectedTopping = (Product)item;

        //                    //_cartViewModel.Items.Add(new OrderItem(selectedTopping, orderItem));
        //                    toppings.Add(new OrderItem(selectedTopping, orderItem));
        //                }

        //                _cartViewModel.Items.Add(orderItem);
        //            }
        //            else
        //            {
        //                _cartViewModel.Items.Add(new OrderItem(menuPosition.Product));
        //            }
        //        }
        //    }
        //    _cartViewModel.TotalPriceChanged();
        //}
    }
}