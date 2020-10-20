using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Domain.Models.Order
{
    public class OrderItem : Entity
    {
        public string Symbol { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [ForeignKey("OrderItem")]
        public int? ParentItemId { get; set; }

        public OrderItem()
        {

        }

        public OrderItem(Product product)
        {
            Symbol = product.Symbol;
            Name = product.Name;
            Price = product.Price;
        }
    }
}