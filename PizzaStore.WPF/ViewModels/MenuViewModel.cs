using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Services;
using PizzaStore.WPF.Commands;
using PizzaStore.WPF.State.Navigators;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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

            AddItemToCartCommand = new AddItemToCartCommand(cartViewModel, this);
            ViewCartCommand = new RenavigateCommand(cartRenavigator);

            MenuItems = FetchData(productDataService);
        }

        private CollectionView FetchData(IProductDataService productDataService)
        {
            var products = Task.Run(() => productDataService.GetAllAsync())
                                          .Result
                                          .OrderBy(q => q.Position);

            var menuItems = new List<MenuPositionViewModel>();

            foreach (var product in products.Where(q => !q.Group.IsTopping))
            {
                var menuItem = new MenuPositionViewModel { Product = product };
                foreach (var topping in products.Where(q => q.Group.IsTopping && q.Group.Name.Contains(product.Group.Name)))
                {
                    if (menuItem.Toppings == null)
                    {
                        menuItem.Toppings = new ObservableCollection<Product>();
                    }
                    menuItem.Toppings.Add(topping);
                }
                menuItems.Add(menuItem);
            }

            var menuItemsView = (CollectionView)CollectionViewSource.GetDefaultView(menuItems);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Product.Group.Name");
            menuItemsView.GroupDescriptions.Add(groupDescription);

            return menuItemsView;
        }
    }
}