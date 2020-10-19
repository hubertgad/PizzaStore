using PizzaStore.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
    public class Order : Entity
    {
        public DateTime OrderPlaced { get; set; }

        public int CustomerId { get; set; }
        
        public Address Address { get; set; }
        
        public string Remarks { get; set; }

        public Customer Customer { get; set; }

        public IEnumerable<ProductOrder> ProductOrders { get; }

        public Order()
        {
            ProductOrders = new List<ProductOrder>();
        }
    }
}