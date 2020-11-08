using PizzaStore.Domain.Models.Menu;
using System.Collections.ObjectModel;

namespace PizzaStore.WPF.Models
{
    public class MenuPosition
    {
        public Product Product { get; set; }
        public ObservableCollection<Product> Toppings { get; set; }
        public int Quantity { get; set; }

        public MenuPosition()
        {
            Quantity = 1;
        }
    }
}