using PizzaStore.WPF.State.Navigators;

namespace PizzaStore.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();
    }
}