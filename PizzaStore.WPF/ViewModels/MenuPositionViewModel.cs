using PizzaStore.Domain.Models.Menu;
using System.Collections.ObjectModel;

namespace PizzaStore.WPF.ViewModels
{
    public class MenuPositionViewModel : ViewModelBase
    {
        public Product Product { get; set; }

        public ObservableCollection<Product> Toppings { get; set; }

        private string _quantity;

        public string Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public MenuPositionViewModel()
        {
            Quantity = "1";
        }
    }
}