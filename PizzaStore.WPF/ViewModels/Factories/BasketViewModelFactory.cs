using PizzaStore.WPF.State.Cart;

namespace PizzaStore.WPF.ViewModels.Factories
{
    class BasketViewModelFactory : IPizzaStoreViewModelFactory<BasketViewModel>
    {
        private readonly ICart _basket;

        public BasketViewModelFactory(ICart basket)
        {
            _basket = basket;
        }

        public BasketViewModel CreateViewModel()
        {
            return new BasketViewModel(_basket);
        }
    }
}