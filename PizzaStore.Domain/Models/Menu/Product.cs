using PizzaStore.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Domain.Models.Menu
{
    public class Product : Entity
    {
        public string Name { get; private set; }

        public decimal NetPrice => Price / Tax.Value;

        public int TaxId { get; private set; }

        public Tax Tax { get; private set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; private set; }

        public int GroupId { get; private set; }

        public Group Group { get; private set; }

        public Product() 
        { }

        public Product(string name, decimal price, int taxId, int groupId)
        {
            Name = name;
            Price = price;
            TaxId = taxId;
            GroupId = groupId;
        }

        public Product(int id, string name, decimal price, int taxId, int groupId)
            : this (name, price, taxId, groupId)
        {
            Id = id;
        }
    }
}