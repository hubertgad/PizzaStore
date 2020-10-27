using PizzaStore.WPF.State.Navigators;
using System;

namespace PizzaStore.WPF.ViewModels.Factories
{
    public class PizzaStoreViewModelAbstractFactory : IPizzaStoreViewModelAbstractFactory
    {
        private readonly IPizzaStoreViewModelFactory<MenuViewModel> _menuViewModelFactory;
        private readonly IPizzaStoreViewModelFactory<CartViewModel> _cartViewModelFactory;
        private readonly IPizzaStoreViewModelFactory<OrderHistoryViewModel> _orderHistoryViewModelFactory;

        public PizzaStoreViewModelAbstractFactory(IPizzaStoreViewModelFactory<MenuViewModel> menuViewModelFactory,
            IPizzaStoreViewModelFactory<CartViewModel> cartViewModelFactory,
            IPizzaStoreViewModelFactory<OrderHistoryViewModel> orderHistoryViewModelFactory)
        {
            _menuViewModelFactory = menuViewModelFactory;
            _cartViewModelFactory = cartViewModelFactory;
            _orderHistoryViewModelFactory = orderHistoryViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.Menu => _menuViewModelFactory.CreateViewModel(),
                ViewType.Cart => _cartViewModelFactory.CreateViewModel(),
                ViewType.OrderHistory => _orderHistoryViewModelFactory.CreateViewModel(),
                _ => throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType")
            };
        }
    }
}