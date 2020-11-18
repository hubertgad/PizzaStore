using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Models.OrderAggregate;
using System.Collections.Generic;

namespace PizzaStore.WPF.ViewModels
{
    public class OrderItemViewModel : ViewModelBase
    {
        public Product Product { get; set; }

        public OrderItemViewModel ParentItem { get; set; }

        public ICollection<OrderItemViewModel> ChildItems { get; set; }

        public OrderItemViewModel(Product product, OrderItemViewModel parentItem = null, ICollection<OrderItemViewModel> childItems = null)
        {
            ChildItems = new List<OrderItemViewModel>();
            Product = product;
            ParentItem = parentItem;
            ChildItems = childItems;
        }

        public OrderItemViewModel(OrderItem orderItem)
        {
            ChildItems = new List<OrderItemViewModel>();
            Product = orderItem.Product;
            foreach (var childItem in orderItem.ChildItems)
            {
                ChildItems.Add(new OrderItemViewModel(childItem));
            }
        }

        public OrderItem ToOrderItem()
        {
            var children = new List<OrderItem>();

            if (ChildItems != null)
            {
                foreach (var child in ChildItems)
                {
                    children.Add(child.ToOrderItem());
                }
            }

            return new OrderItem(Product, null, children);
        }
    }
}