using PizzaStore.WPF.State.Navigators;
using PizzaStore.WPF.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace PizzaStore.WPF.Commands
{
    class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;

        private readonly IPizzaStoreViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IPizzaStoreViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType viewType)
            {
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}