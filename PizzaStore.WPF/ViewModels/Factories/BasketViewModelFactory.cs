using PizzaStore.WPF.State.Cart;

namespace PizzaStore.WPF.ViewModels.Factories
{
    class BasketViewModelFactory : IPizzaStoreViewModelFactory<CartViewModel>
    {
        private readonly ICart _basket;

        public BasketViewModelFactory(ICart basket)
        {
            _basket = basket;
        }

        public CartViewModel CreateViewModel()
        {
            return new CartViewModel(_basket);
        }
    }
}