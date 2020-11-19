using PizzaStore.Domain.Services;
using PizzaStore.WPF.State.Authenticators;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PizzaStore.WPF.ViewModels
{
    public class OrderHistoryViewModel : ViewModelBase
    {
        public ObservableCollection<OrderViewModel> Orders { get; set; }

        public OrderHistoryViewModel(IAuthenticator authenticator, IOrderDataService orderDataService)
        {
            Orders = new ObservableCollection<OrderViewModel>();

            foreach (var order in Task.Run(() => orderDataService.GetAllAsync(authenticator.CurrentUser)).Result)
            {
                Orders.Add(new OrderViewModel(order));
            }
        }
    }
}