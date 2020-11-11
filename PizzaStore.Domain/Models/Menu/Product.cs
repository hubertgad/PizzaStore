using PizzaStore.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Domain.Models.Menu
{
    public class Product : Entity
    {
        public string Name { get; private set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; private set; }

        public virtual Group Group { get; private set; }

        public Product()
        { }

        public Product(string name, decimal price, Group group)
        {
            Name = name;
            Price = price;
            Group = group;
        }
    }
}