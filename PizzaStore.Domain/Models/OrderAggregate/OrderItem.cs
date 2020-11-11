using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.SeedWork;

namespace PizzaStore.Domain.Models.OrderAggregate
{
    public class OrderItem : Entity
    {
        public virtual Product Product { get; private set; }

        public virtual OrderItem ParentItem { get; private set; }

        public OrderItem()
        { }

        public OrderItem(Product product, OrderItem parentItem = null)
        {
            Product = product;
            ParentItem = parentItem;
        }
    }
}