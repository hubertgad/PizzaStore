using PizzaStore.WPF.ViewModels;
using System.Windows.Input;

namespace PizzaStore.WPF.State.Navigators
{
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }

        ICommand UpdateCurrentViewModelCommand { get; }
    }

    public enum ViewType
    {
        Menu, Basket, OrderHistory
    }
}