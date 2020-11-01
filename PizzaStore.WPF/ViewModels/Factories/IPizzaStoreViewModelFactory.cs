using PizzaStore.WPF.State.Navigators;

namespace PizzaStore.WPF.ViewModels.Factories
{
    public interface IPizzaStoreViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}