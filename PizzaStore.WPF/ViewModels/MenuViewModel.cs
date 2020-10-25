using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Models.Order;
using PizzaStore.WPF.Commands;
using PizzaStore.WPF.State.Cart;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaStore.WPF.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public ICart Cart { get; }

        public IEnumerable<Product> Products { get; }

        public IEnumerable<Product> MainProducts =>
            Products.Where(q => !q.Group.IsTopping);

        public IEnumerable<Product> Pizzas => 
            Products.Where(q => q.Group.Name == "Pizza");

        public IEnumerable<Product> PizzaToppings => 
            Products.Where(q => q.Group.Name == "PizzaTopping");


        public MenuViewModel(ICart cart, IEnumerable<Product> products)
        {
            Products = products;
            Cart = cart;
        }
    }
}