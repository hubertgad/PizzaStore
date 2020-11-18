using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.Domain.Services;
using PizzaStore.WPF.State.Authenticators;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.WPF.ViewModels
{
    public class OrderHistoryViewModel : ViewModelBase
    {
        public ICollection<Order> Orders { get; set; }

        public ObservableCollection<OrderViewModel> Orders2 { get; set; }

        public OrderHistoryViewModel(IAuthenticator authenticator, IOrderDataService orderDataService)
        {
            Orders = Task.Run(() => orderDataService.GetAllAsync(authenticator.CurrentUser)).Result;

            Orders2 = new ObservableCollection<OrderViewModel>();

            foreach (var order in Orders)
            {
                Orders2.Add(new OrderViewModel(order));
            }

        }
    }
}