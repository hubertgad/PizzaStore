using PizzaStore.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PizzaStore.Domain.Models.Order
{
    public class Order : Entity
    {
        public DateTime OrderPlaced { get; private set; }

        public string Remarks { get; private set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; private set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; private set; }

        public Address Address { get; private set; }

        public Customer Customer { get; private set; }

        public IEnumerable<OrderItem> OrderItems { get; private set; }

        public Order()
        { }

        public Order(string remarks, decimal discount, decimal totalPrice, Address address, Customer customer, IEnumerable<OrderItem> orderItems)
        {
            OrderPlaced = DateTime.Now;
            Remarks = remarks;
            Discount = discount;
            TotalPrice = totalPrice;
            Address = address;
            Customer = customer;
            OrderItems = orderItems;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Order placed: { OrderPlaced }");
            sb.AppendLine();

            sb.AppendLine($"Customer information:");
            sb.AppendLine($"\tName: { Customer.Name }");
            sb.AppendLine($"\tPhone: { Customer.Phone}");
            sb.AppendLine($"\tE-mail address: { Customer.Email}");
            sb.AppendLine($"\tAddress: { Address }");
            sb.AppendLine();

            sb.AppendLine($"Remarks: { Remarks }");
            sb.AppendLine();

            sb.AppendLine($"Products:");
            foreach (var item in OrderItems)
            {
                sb.AppendLine($"\t{ item }");
            }
            sb.AppendLine();

            sb.AppendLine($"Total price: { string.Format("{0:C2}", TotalPrice) }");

            return sb.ToString();
        }
    }
}