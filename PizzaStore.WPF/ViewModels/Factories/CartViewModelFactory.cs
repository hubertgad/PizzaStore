using PizzaStore.WPF.State.Cart;

namespace PizzaStore.WPF.ViewModels.Factories
{
    class CartViewModelFactory : IPizzaStoreViewModelFactory<CartViewModel>
    {
        private readonly ICart _cart;

        public CartViewModelFactory(ICart cart)
        {
            _cart = cart;
        }

        public CartViewModel CreateViewModel()
        {
            return new CartViewModel(_cart);
        }
    }
}