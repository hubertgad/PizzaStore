using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Domain.Models.OrderAggregate
{
    public class OrderItem : Entity
    {
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [ForeignKey("OrderItem")]
        public int? ParentItemId { get; set; }

        public OrderItem()
        { }

        public OrderItem(Product product, int? parentItemId = null)
        {
            Name = product.Name;

            Price = product.Price;

            ParentItemId = parentItemId;
        }

        public override string ToString()
        {
            return $"{ Name } { string.Format("{0:C2}", Price) }";
        }
    }
}