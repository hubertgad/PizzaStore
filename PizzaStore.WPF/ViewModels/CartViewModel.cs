using PizzaStore.Domain.Models;
using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.Domain.Services;
using PizzaStore.Domain.Services.EmailServices;
using PizzaStore.WPF.Commands;
using PizzaStore.WPF.State.Authenticators;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PizzaStore.WPF.ViewModels
{
    public class CartViewModel : ViewModelBase
    {
        public User User { get; set; }

        public ObservableCollection<OrderItem> Items { get; set; }

        public decimal TotalPrice => Items.Sum(q => q.Product.Price);

        public string Remarks { get; set; }

        public string Street { get; set; }

        public string Building { get; set; }

        public string Unit { get; set; }

        public ICommand RemoveItemFromCartCommand { get; set; }

        public ICommand PlaceOrderCommand { get; set; }

        public MessageViewModel StatusMessageViewModel { get; set; }

        public MessageViewModel ErrorMessageViewModel { get; set; }

        public string StatusMessage { set => StatusMessageViewModel.Message = value; }

        public string ErrorMessage { set => ErrorMessageViewModel.Message = value; }

        public CartViewModel(IAuthenticator authenticator, IOrderDataService orderService, IEmailService emailService)
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
            PlaceOrderCommand = new PlaceOrderCommand(this, orderService, emailService);

            StatusMessageViewModel = new MessageViewModel();
            ErrorMessageViewModel = new MessageViewModel();
        }

        public void TotalPriceChanged() => OnPropertyChanged(nameof(TotalPrice));
    }
}