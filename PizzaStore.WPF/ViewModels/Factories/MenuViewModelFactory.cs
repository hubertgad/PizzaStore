using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models.Menu;
using PizzaStore.WPF.State.Cart;

namespace PizzaStore.WPF.ViewModels.Factories
{
    public class MenuViewModelFactory : IPizzaStoreViewModelFactory<MenuViewModel>
    {
        private readonly IDataService<Product> _productDataService;
        private readonly ICart _basket;

        public MenuViewModelFactory(IDataService<Product> productDataService, ICart basket)
        {
            _productDataService = productDataService;
            _basket = basket;
        }

        public MenuViewModel CreateViewModel()
        {
            return new MenuViewModel(_basket, _productDataService.GetAll().Result);
        }
    }
}