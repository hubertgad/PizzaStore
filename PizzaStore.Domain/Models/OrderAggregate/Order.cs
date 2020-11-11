using PizzaStore.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Domain.Models.OrderAggregate
{
    public class Order : Entity
    {
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; private set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; private set; }

        public string Remarks { get; private set; }

        public virtual Address Address { get; private set; }

        public virtual User User { get; private set; }

        public virtual IEnumerable<OrderItem> OrderItems { get; private set; }

        public DateTime Placed { get; private set; }

        public Order()
        { }

        public Order(string remarks, decimal discount, decimal totalPrice, User user, Address address, IEnumerable<OrderItem> orderItems)
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