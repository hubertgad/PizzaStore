using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models.Menu;
using PizzaStore.WPF.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;

namespace PizzaStore.WPF.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public CartViewModel Cart { get; }

        public CollectionView MenuItems { get; }

        public MenuViewModel(IProductDataService productDataService, CartViewModel cartViewModel)
        {
            Cart = cartViewModel;

            var products = productDataService.GetAll();

            var menuItems = new ObservableCollection<MenuPosition>();

            foreach (var product in products.Where(q => !q.Group.IsTopping))
            {
                var tempProduct = new MenuPosition { Product = product };
                foreach (var topping in products.Where(q => q.Group.IsTopping && q.Group.Name.Contains(product.Group.Name)))
                {
                    if (tempProduct.Toppings == null)
                    {
                        tempProduct.Toppings = new ObservableCollection<Product>();
                    }
                    tempProduct.Toppings.Add(topping);
                }
                menuItems.Add(tempProduct);
            }

            MenuItems = (CollectionView)CollectionViewSource.GetDefaultView(menuItems);
            PropertyGroupDescription groupDescription3 = new PropertyGroupDescription("Product.Group.Name");
            MenuItems.GroupDescriptions.Add(groupDescription3);
        }
    }
}