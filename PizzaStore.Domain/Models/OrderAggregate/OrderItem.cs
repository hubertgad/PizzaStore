using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.SeedWork;
using System.Collections.Generic;

namespace PizzaStore.Domain.Models.OrderAggregate
{
    public class OrderItem : Entity
    {
        public virtual Order Order { get; internal set; }

        public virtual Product Product { get; private set; }

        public virtual OrderItem ParentItem { get; internal set; }

        public virtual ICollection<OrderItem> ChildItems { get; private set; }

        public OrderItem()
        { }

        public OrderItem(Product product, OrderItem parentItem = null, ICollection<OrderItem> childItems = null)
        {
            Product = product;
            ParentItem = parentItem;
            ChildItems = childItems;
        }
    }
}