using PizzaStore.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Domain.Models.Menu
{
    public class Product : Entity
    {
        public string Name { get; private set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal NetPrice { get; private set; }

        public Tax Tax { get; private set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; private set; }

        public Group Group { get; private set; }

        public Product(string name, decimal price, Tax tax, Group group)
        {
            Name = name;
            Price = price;
            Tax = tax;
            Group = group;
            NetPrice = Price / Tax.Value;
        }
    }
}