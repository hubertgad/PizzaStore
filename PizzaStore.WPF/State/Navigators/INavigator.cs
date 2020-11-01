using PizzaStore.WPF.ViewModels;
using System;

namespace PizzaStore.WPF.State.Navigators
{
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }

        event Action StateChanged;
    }

    public enum ViewType
    {
        Menu, Cart, OrderHistory, Login
    }
}