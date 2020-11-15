using PizzaStore.Domain.SeedWork;
using System.Collections.Generic;

namespace PizzaStore.Domain.Models.Menu
{
    public class Group : Entity
    {
        public string Name { get; private set; }

        public bool IsTopping { get; private set; }

        public virtual ICollection<Product> Products { get; private set; }

        public Group()
        { }

        public Group(string name, bool isTopping)
        {
            Name = name;
            IsTopping = isTopping;
            Products = new List<Product>();
        }
    }
}