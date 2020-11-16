using PizzaStore.Domain.Models;
using PizzaStore.Domain.Models.Menu;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PizzaStore.WPF.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        public User User { get; }

        public ObservableCollection<OrderItemViewModel> Items { get; }

        public decimal TotalPrice => Items.Sum(q => q.Product.Price + q.ChildItems.Sum(w => w.Product.Price));

        public string Remarks { get; set; }

        public string Street { get; set; } = string.Empty;

        public string Building { get; set; } = string.Empty;

        public string Unit { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public OrderViewModel(User user)
        {
            User = user;

            if (User.Orders.LastOrDefault() != null && User.Orders.LastOrDefault().Address != null)
            {
                var address = User.Orders.LastOrDefault().Address;

                Street = address.Street.Name;
                Building = address.Building;
                Unit = address.Unit;
                ZipCode = address.ZipCode.Code;
                City = address.City.Name;
            }

            Items = new ObservableCollection<OrderItemViewModel>();
        }

        public void TotalPriceChanged() => OnPropertyChanged(nameof(TotalPrice));
    }

    public class OrderItemViewModel : ViewModelBase
    {
        public Product Product { get; set; }

        public OrderItemViewModel ParentItem { get; set; }

        public ICollection<OrderItemViewModel> ChildItems { get; set; }

        public OrderItemViewModel(Product product, OrderItemViewModel parentItem = null, ICollection<OrderItemViewModel> childItems = null)
        {
            Product = product;
            ParentItem = parentItem;
            ChildItems = childItems;
        }
    }
}