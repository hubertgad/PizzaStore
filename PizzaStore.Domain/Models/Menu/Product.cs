using PizzaStore.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Domain.Models.Menu
{
    public class Product : Entity
    {
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal NetPrice { get; set; }

        public Tax Tax { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public Group Group { get; set; }

        public Product()
        {
        }

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