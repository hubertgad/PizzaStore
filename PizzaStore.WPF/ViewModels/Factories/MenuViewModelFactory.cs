using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models.Menu;
using PizzaStore.WPF.State.Cart;

namespace PizzaStore.WPF.ViewModels.Factories
{
    public class MenuViewModelFactory : IPizzaStoreViewModelFactory<MenuViewModel>
    {
        private readonly IDataService<Product> _productDataService;
        private readonly ICart _cart;

        public MenuViewModelFactory(IDataService<Product> productDataService, ICart cart)
        {
            _productDataService = productDataService;
            _cart = cart;
        }

        public MenuViewModel CreateViewModel()
        {
            return new MenuViewModel(_cart, _productDataService);
        }
    }
}