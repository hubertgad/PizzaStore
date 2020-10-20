using PizzaStore.WPF.State.Basket;

namespace PizzaStore.WPF.ViewModels.Factories
{
    class BasketViewModelFactory : IPizzaStoreViewModelFactory<BasketViewModel>
    {
        private readonly IBasket _basket;

        public BasketViewModelFactory(IBasket basket)
        {
            _basket = basket;
        }

        public BasketViewModel CreateViewModel()
        {
            return new BasketViewModel(_basket);
        }
    }
}