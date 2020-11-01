using PizzaStore.Domain.Models.OrderAggregate;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PizzaStore.WPF.State.Cart
{
    public interface ICart
    {
        decimal TotalPrice { get; }

        ICommand AddItemToCartCommand { get; set; }

        ICommand RemoveItemFromCartCommand { get; set; }

        ICommand PlaceOrderCommand { get; set; }

        ObservableCollection<OrderItem> Items { get; set; }

        void AddItem(OrderItem orderItem);

        void RemoveItem(OrderItem orderItem);

        void PlaceOrder();
    }
}