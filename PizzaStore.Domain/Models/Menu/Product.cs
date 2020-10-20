using PizzaStore.Domain.SeedWork;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Domain.Models.Menu
{
    public class Product : IEntity
    {
        [Key]
        public string Symbol { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public ProductType ProductType { get; set; }
    }

    public enum ProductType
    {
        Pizza, PizzaTopping, MainMeal, MainMealTopping
    }
}