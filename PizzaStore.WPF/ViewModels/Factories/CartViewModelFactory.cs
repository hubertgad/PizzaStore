namespace PizzaStore.WPF.ViewModels.Factories
{
    class CartViewModelFactory : IPizzaStoreViewModelFactory<CartViewModel>
    {
        public CartViewModel CreateViewModel()
        {
            return new CartViewModel();
        }
    }
}
