using PizzaStore.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Domain.Models.Menu
{
    public class Product : Entity
    {
        public string Name { get; private set; }

        //public decimal NetPrice => Price / Tax.Value;

        //public int TaxId { get; private set; }

        //public Tax Tax { get; private set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; private set; }

        public int GroupId { get; private set; }

        public Group Group { get; private set; }

        public Product() 
        { }

        public Product(string name, decimal price, /*Tax tax,*/ Group group)
        {
            Name = name;
            Price = price;
            //TaxId = tax.Id;
            GroupId = group.Id;
        }

        public Product(int id, string name, decimal price, /*Tax tax,*/ Group group)
            : this (name, price, /*tax,*/ group)
        {
            Id = id;
        }
    }
}