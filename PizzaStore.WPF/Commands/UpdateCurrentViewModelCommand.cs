using PizzaStore.WPF.State.Navigators;
using PizzaStore.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace PizzaStore.WPF.Commands
{
    class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                
                _navigator.CurrentViewModel = viewType switch
                {
                    ViewType.Menu => new MenuViewModel(),
                    ViewType.Cart => new CartViewModel(),
                    ViewType.OrderHistory => new OrderHistoryViewModel(),
                    _ => null
                };
            }
        }
    }
}