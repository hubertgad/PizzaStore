namespace PizzaStore.WPF.ViewModels.Factories
{
    class OrderHistoryViewModelFactory : IPizzaStoreViewModelFactory<OrderHistoryViewModel>
    {
        public OrderHistoryViewModel CreateViewModel()
        {
            return new OrderHistoryViewModel();
        }
    }
}