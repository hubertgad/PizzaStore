using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models;

namespace PizzaStore.WPF.ViewModels.Factories
{
    public class MenuViewModelFactory : IPizzaStoreViewModelFactory<MenuViewModel>
    {
        private readonly IDataService<Pizza> _productDataService;

        public MenuViewModelFactory(IDataService<Pizza> productDataService)
        {
            _productDataService = productDataService;
        }

        public MenuViewModel CreateViewModel()
        {
            return new MenuViewModel(_productDataService.GetAll().Result);
        }
    }
}