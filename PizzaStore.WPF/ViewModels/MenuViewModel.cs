using PizzaStore.Domain.Models;
using System.Collections.Generic;

namespace PizzaStore.WPF.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public IEnumerable<Pizza> Pizzas { get; }

        public Order Order { get; set; }

        public MenuViewModel(IEnumerable<Pizza> products)
        {
            Pizzas = products;
            Order = new Order();
        }
    }
}