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
            if (Int32.TryParse((string)values[1], out int qty) && qty > 0)
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
            var values = (object[])parameter;

            Int32.TryParse((string)values[1], out int qty);

            for (int i = 0; i < qty; i++)
            {
                if ((Product)values[0] is Product product)
                {
                    var orderItem = new OrderItem(product);
                    _cartViewModel.AddItem(orderItem);

                    if (values.Length > 2)
                    {
                        foreach (var item in (ICollection)values[2])
                        {
                            var item2 = (Product)item;

                            var orderItemTopping = new OrderItem(item2)
                            {
                                ParentItem = orderItem
                            };

                            orderItemTopping.Name = "+ " + orderItemTopping.Name;

                            _cartViewModel.AddItem(orderItemTopping);
                        }
                    }
                }
            }
        }
    }
}