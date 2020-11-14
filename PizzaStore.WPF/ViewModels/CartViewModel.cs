using PizzaStore.Domain.Models;
using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.Domain.Services.OrderServices;
using PizzaStore.WPF.Commands;
using PizzaStore.WPF.State.Authenticators;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PizzaStore.WPF.ViewModels
{
    public class CartViewModel : ViewModelBase
    {
        public User User { get; }

        public ObservableCollection<OrderItem> Items { get; }

        public decimal TotalPrice => Items.Sum(q => q.Product.Price);

        public string Remarks { get; set; }

        public string Street { get; set; }

        public string Building { get; set; }

        public ushort Unit { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public ICommand RemoveItemFromCartCommand { get; }

        public ICommand PlaceOrderCommand { get; }

        public MessageViewModel StatusMessageViewModel { get; }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string StatusMessage { set => StatusMessageViewModel.Message = value; }

        public string ErrorMessage { set => ErrorMessageViewModel.Message = value; }

        public CartViewModel(IAuthenticator authenticator, IPlaceOrderService placeOrderService)
        {
            User = authenticator.CurrentUser;

            if (User.Orders.LastOrDefault() != null && User.Orders.LastOrDefault().Address != null)
            {
                var address = User.Orders.LastOrDefault().Address;

                Street = address.Street;
                Building = address.Building;
                Unit = address.Unit;
            }

            Items = new ObservableCollection<OrderItem>();

            RemoveItemFromCartCommand = new RemoveItemFromCartCommand(this);
            PlaceOrderCommand = new PlaceOrderCommand(this, placeOrderService);

            StatusMessageViewModel = new MessageViewModel();
            ErrorMessageViewModel = new MessageViewModel();
        }

        public void TotalPriceChanged() => OnPropertyChanged(nameof(TotalPrice));
    }
}