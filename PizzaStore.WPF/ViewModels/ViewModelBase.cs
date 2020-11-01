using PizzaStore.WPF.Models;

namespace PizzaStore.WPF.ViewModels
{
    public delegate TViewModel CreateViewModel<out TViewModel>() where TViewModel : ViewModelBase;

    public class ViewModelBase : ObservableObject
    {

    }
}