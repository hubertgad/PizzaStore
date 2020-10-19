namespace PizzaStore.WPF.ViewModels.Factories
{
    public interface IPizzaStoreViewModelFactory<out T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}