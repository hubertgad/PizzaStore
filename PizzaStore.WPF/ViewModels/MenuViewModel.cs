using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Models.Order;
using PizzaStore.WPF.State.Basket;
using System.Collections.Generic;
using System.Linq;

namespace PizzaStore.WPF.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public IEnumerable<Product> Products { get; }

        public IEnumerable<Product> Pizzas => Products.Where(q => q.ProductType == ProductType.Pizza);

        public IEnumerable<Product> PizzaToppings => Products.Where(q => q.ProductType == ProductType.PizzaTopping);

        public IBasket Basket { get; set; }

        public MenuViewModel(IBasket basket, IEnumerable<Product> products)
        {
            Products = products;
            Basket = basket;
            basket.Order.AddItem(new OrderItem { Name = "Test", Price = 2 });
        }
    }
}