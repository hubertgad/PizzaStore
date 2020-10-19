using PizzaStore.WPF.State.Navigators;

namespace PizzaStore.WPF.ViewModels.Factories
{
    public interface IPizzaStoreViewModelAbstractFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}