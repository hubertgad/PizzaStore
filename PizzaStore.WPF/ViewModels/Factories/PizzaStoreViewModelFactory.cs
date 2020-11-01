using PizzaStore.WPF.State.Navigators;
using System;

namespace PizzaStore.WPF.ViewModels.Factories
{
    public class PizzaStoreViewModelFactory : IPizzaStoreViewModelFactory
    {
        private readonly CreateViewModel<MenuViewModel> _createMenuViewModel;
        private readonly CreateViewModel<CartViewModel> _createCartViewModel;
        private readonly CreateViewModel<OrderHistoryViewModel> _createOrderHistoryViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;

        public PizzaStoreViewModelFactory(CreateViewModel<MenuViewModel> createMenuViewModel, 
            CreateViewModel<CartViewModel> createCartViewModel, 
            CreateViewModel<OrderHistoryViewModel> createOrderHistoryViewModel, 
            CreateViewModel<LoginViewModel> createLoginViewModel)
        {
            _createMenuViewModel = createMenuViewModel;
            _createCartViewModel = createCartViewModel;
            _createOrderHistoryViewModel = createOrderHistoryViewModel;
            _createLoginViewModel = createLoginViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.Login => _createLoginViewModel(),
                ViewType.Menu => _createMenuViewModel(),
                ViewType.Cart => _createCartViewModel(),
                ViewType.OrderHistory => _createOrderHistoryViewModel(),
                _ => throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType")
            };
        }
    }
}