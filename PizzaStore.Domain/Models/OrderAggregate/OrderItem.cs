using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.SeedWork;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Domain.Models.OrderAggregate
{
    public class OrderItem : Entity
    {
        //public string Name { get; private set; }

        //[Column(TypeName = "decimal(18, 2)")]
        //public decimal Price { get; private set; }

        public int ProductId { get; private set; }

        public Product Product { get; private set; }

        [ForeignKey("OrderItem")]
        public int? ParentItemId { get; private set; }

        public OrderItem ParentItem { get; private set; }

        public OrderItem()
        { }

        public OrderItem(Product product, OrderItem parentItem = null)
        {
            Product = product;
            ParentItem = parentItem;
        }

        public OrderItem(int productId, OrderItem parentItem = null)
        {
            ProductId = productId;
            ParentItem = parentItem;
        }

        public override string ToString()
        {
            return $"{ Product.Name } { string.Format("{0:C2}", Product.Price) }";
        }
    }
}