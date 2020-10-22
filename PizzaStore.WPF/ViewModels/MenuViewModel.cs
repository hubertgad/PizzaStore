using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Models.Order;
using PizzaStore.WPF.Commands;
using PizzaStore.WPF.State.Cart;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PizzaStore.WPF.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public IEnumerable<Product> Products { get; }

        public IEnumerable<Product> Pizzas => Products.Where(q => q.ProductType == ProductType.Pizza);

        public IEnumerable<Product> PizzaToppings => Products.Where(q => q.ProductType == ProductType.PizzaTopping);

        public ICart Basket { get; set; }

        private ICommand _addItemToCartCommand;

        public ICommand AddCommand
        {
            get { return _addItemToCartCommand ??= new AddItemToCartCommand(Basket); }
            set { _addItemToCartCommand = value; }
        }

        public MenuViewModel(ICart basket, IEnumerable<Product> products)
        {
            Products = products;
            Basket = basket;
            basket.Order.AddItem(new OrderItem { Name = "Test", Price = 2 });
        }
    }
}