using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models.Menu;
using PizzaStore.WPF.Commands;
using PizzaStore.WPF.State.Navigators;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace PizzaStore.WPF.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public CartViewModel Cart { get; }

        public CollectionView MenuItems { get; }

        public ICommand AddItemToCartCommand { get; set; }

        public ICommand ViewCartCommand { get; set; }

        public MenuViewModel(IProductDataService productDataService, CartViewModel cartViewModel, IRenavigator cartRenavigator)
        {
            Cart = cartViewModel;

            AddItemToCartCommand = new AddItemToCartCommand(cartViewModel);
            ViewCartCommand = new RenavigateCommand(cartRenavigator);

            var products = productDataService.GetAll();

            var menuItems = new ObservableCollection<MenuPositionViewModel>();

            foreach (var product in products.Where(q => !q.Group.IsTopping))
            {
                var tempProduct = new MenuPositionViewModel { Product = product };
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