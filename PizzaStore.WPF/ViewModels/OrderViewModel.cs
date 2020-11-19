using PizzaStore.Domain.Models;
using PizzaStore.Domain.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PizzaStore.WPF.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        public User User { get; }

        public ObservableCollection<OrderItemViewModel> Items { get; }

        public decimal TotalPrice => Items.Sum(q => q.Product.Price + q.ChildItems.Sum(w => w.Product.Price));

        public int Id { get; }

        public string Remarks { get; set; }

        public string Street { get; set; } = string.Empty;

        public string Building { get; set; } = string.Empty;

        public string Unit { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public DateTime Placed { get; set; }

        public OrderViewModel(User user)
        {
            User = user;

            if (User.Orders.LastOrDefault() != null && User.Orders.LastOrDefault().Address != null)
            {
                var address = User.Orders.LastOrDefault().Address;

                Street = address.Street.Name;
                Building = address.Building;
                Unit = address.Unit;
                ZipCode = address.ZipCode.Code;
                City = address.City.Name;
            }

            Items = new ObservableCollection<OrderItemViewModel>();
        }

        public OrderViewModel(Order order)
        {
            User = order.User;
            Items = new ObservableCollection<OrderItemViewModel>();

            foreach (var item in order.OrderItems)
            {
                if (item.ParentItem == null)
                {
                    Items.Add(new OrderItemViewModel(item));
                }
            }
            Id = order.Id;
            Remarks = order.Remarks;
            Street = order.Address.Street.Name;
            Building = order.Address.Building;
            Unit = order.Address.Unit;
            ZipCode = order.Address.ZipCode.Code;
            City = order.Address.City.Name;
            Placed = order.Placed;
        }

        public void TotalPriceChanged() => OnPropertyChanged(nameof(TotalPrice));

        public Order ToOrder()
        {
            var address = new Address(Street, Building, Unit, ZipCode, City);
            var orderItems = new List<OrderItem>();

            foreach (var item in Items)
            {
                orderItems.Add(item.ToOrderItem());
            }

            return new Order(Remarks, 0, TotalPrice, User, address, orderItems);
        }
    }
}