using PizzaStore.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Domain.Models.Menu
{
    public class Product : Entity
    {
        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public short Position { get; set; }

        public bool IsActive { get; set; }

        public virtual Group Group { get; private set; }

        public Product()
        { }

        public Product(string name, decimal price, Group group, short position = 0)
        {
            Name = name;
            Price = price;
            Group = group;
            Position = position;
            IsActive = true;
        }
    }
}