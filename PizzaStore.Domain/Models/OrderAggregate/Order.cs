using PizzaStore.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace PizzaStore.Domain.Models.OrderAggregate
{
    public class Order : Entity
    {
        public decimal TotalPrice { get; internal set; }

        public decimal Discount { get; internal set; }

        public string Remarks { get; internal set; }

        public virtual Address Address { get; internal set; }

        public virtual User User { get; private set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public DateTime Placed { get; private set; }

        public Order()
        { }

        public Order(string remarks, decimal discount, decimal totalPrice, User user, Address address, ICollection<OrderItem> orderItems)
        {
            Remarks = remarks;
            Discount = discount;
            TotalPrice = totalPrice;
            User = user;
            Address = address;
            OrderItems = orderItems;
            Placed = DateTime.Now;
        }
    }
}