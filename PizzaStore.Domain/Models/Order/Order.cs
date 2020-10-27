using PizzaStore.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Domain.Models.Order
{
    public class Order : Entity
    {
        public DateTime OrderPlaced { get; private set; }

        public int CustomerId { get; private set; }
        
        public string Remarks { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }

        public Address Address { get; set; }

        public Customer Customer { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public Order(int customerId, string remarks, decimal discount, decimal totalPrice, Address address, Customer customer, IEnumerable<OrderItem> orderItems)
        {
            OrderPlaced = DateTime.Now;
            CustomerId = customerId;
            Remarks = remarks;
            Discount = discount;
            TotalPrice = totalPrice;
            Address = address;
            Customer = customer;
            OrderItems = orderItems;
        }
    }
}