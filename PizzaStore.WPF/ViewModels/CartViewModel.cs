using PizzaStore.Domain.Models;
using PizzaStore.Domain.Services.OrderServices;
using PizzaStore.WPF.Commands;
using PizzaStore.WPF.State.Authenticators;
using System.Windows.Input;

namespace PizzaStore.WPF.ViewModels
{
    public class CartViewModel : ViewModelBase
    {
        public User User { get; }

        public ICommand RemoveItemFromCartCommand { get; }

        public ICommand PlaceOrderCommand { get; }

        public MessageViewModel StatusMessageViewModel { get; }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string StatusMessage { set => StatusMessageViewModel.Message = value; }

        public string ErrorMessage { set => ErrorMessageViewModel.Message = value; }

        public OrderViewModel OrderViewModel { get; set; }

        public CartViewModel(IAuthenticator authenticator, IPlaceOrderService placeOrderService)
        {
            User = authenticator.CurrentUser;

            OrderViewModel = new OrderViewModel(authenticator.CurrentUser);

            RemoveItemFromCartCommand = new RemoveItemFromCartCommand(this);
            PlaceOrderCommand = new PlaceOrderCommand(this, placeOrderService);

            StatusMessageViewModel = new MessageViewModel();
            ErrorMessageViewModel = new MessageViewModel();
        }

        public void OrderViewModelChanged() => OnPropertyChanged(nameof(OrderViewModel));
    }
}