using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models.Menu;
using PizzaStore.WPF.State.Basket;

namespace PizzaStore.WPF.ViewModels.Factories
{
    public class MenuViewModelFactory : IPizzaStoreViewModelFactory<MenuViewModel>
    {
        private readonly IDataService<Product> _productDataService;
        private readonly IBasket _basket;

        public MenuViewModelFactory(IDataService<Product> productDataService, IBasket basket)
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