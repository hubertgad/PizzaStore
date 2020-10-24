using PizzaStore.WPF.State.Cart;
using PizzaStore.WPF.State.Navigators;

namespace PizzaStore.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; } 
        
        public ICart Cart { get; set; } 

        public MainViewModel(INavigator navigator, ICart cart)
        {
            Navigator = navigator;
            Cart = cart;
        }
    }
}