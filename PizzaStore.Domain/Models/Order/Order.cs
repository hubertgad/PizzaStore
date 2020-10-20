using PizzaStore.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Domain.Models.Order
{
    public class Order : Entity
    {
        public DateTime OrderPlaced { get; set; }

        public int CustomerId { get; set; }
        
        public string Remarks { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }

        public Address Address { get; set; }

        public Customer Customer { get; set; }

        public List<OrderItem> OrderItems { get; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public void AddItem(OrderItem item)
        {
            OrderItems.Add(item);
            TotalPrice += item.Price;
        }
    }
}