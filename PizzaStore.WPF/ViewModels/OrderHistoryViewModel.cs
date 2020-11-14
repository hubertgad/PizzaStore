using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.Domain.Services;
using PizzaStore.WPF.State.Authenticators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.WPF.ViewModels
{
    public class OrderHistoryViewModel : ViewModelBase
    {
        public IEnumerable<Order> Orders { get; }

        public OrderHistoryViewModel(IAuthenticator authenticator, IOrderDataService orderDataService)
        {
            Orders = Task.Run(() => orderDataService.GetAllAsync(authenticator.CurrentUser)).Result;
        }
    }
}