using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.WPF.State.Cart;
using System;
using System.Collections;
using System.Windows.Input;

namespace PizzaStore.WPF.Commands
{
    class AddItemToCartCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly ICart _cart;

        public AddItemToCartCommand(ICart cart)
        {
            _cart = cart;
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

        public void Execute(object parameter)
        {
            var values = (object[])parameter;

            Int32.TryParse((string)values[1], out int qty);

            for (int i = 0; i < qty; i++)
            {
                if ((Product)values[0] is Product product)
                {
                    var orderItem = new OrderItem(product);
                    _cart.AddItem(orderItem);

                    if (values.Length > 2)
                    {
                        foreach (var item in (ICollection)values[2])
                        {
                            var item2 = (Product)item;

                            var orderItemTopping = new OrderItem(item2)
                            {
                                ParentItemId = orderItem.Id
                            };

                            orderItemTopping.Name = "+ " + orderItemTopping.Name;

                            _cart.AddItem(orderItemTopping);
                        }
                    }
                }
            }
        }
    }
}