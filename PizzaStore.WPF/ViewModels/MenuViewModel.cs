using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.WPF.State.Cart;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PizzaStore.WPF.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public ICart Cart { get; }

        public IEnumerable<Product> Products { get; }

        public IEnumerable<Product> Pizzas =>
            Products.Where(q => q.Group.Name == "Pizza");

        public IEnumerable<Product> PizzaToppings =>
            Products.Where(q => q.Group.Name == "PizzaTopping");

        public IEnumerable<Product> Mains =>
            Products.Where(q => q.Group.Name == "MainMeal");

        public IEnumerable<Product> MainToppings =>
            Products.Where(q => q.Group.Name == "MainMealTopping");

        public IEnumerable<Product> Soups =>
            Products.Where(q => q.Group.Name == "Soup");

        public IEnumerable<Product> Drinks =>
            Products.Where(q => q.Group.Name == "Drink");
        
        public ObservableCollection<OrderItem> Items => Cart.Items;

        public MenuViewModel(ICart cart, IProductDataService productDataService)
        {
            Products = productDataService.GetAll();
            Cart = cart;
        }
    }
}