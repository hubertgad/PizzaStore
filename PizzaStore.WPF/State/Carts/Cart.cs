using PizzaStore.Domain.Models.Order;
using PizzaStore.WPF.Commands;
using PizzaStore.WPF.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PizzaStore.WPF.State.Cart
{
    class Cart : ObservableObject, ICart
    {
        public ObservableCollection<OrderItem> Items { get; set; }

        public decimal TotalPrice => Items.Sum(q => q.Price);
        
        private string _remarks;

        public string Remarks
        {
            get { return _remarks; }
            set 
            {
                _remarks = value;
                OnPropertyChanged(nameof(Remarks));
            }
        }

        public ICommand AddItemToCartCommand { get; set; }

        public ICommand RemoveItemFromCartCommand { get; set; }

        public ICommand PlaceOrderCommand { get; set; }

        public Cart()
        {
            Items = new ObservableCollection<OrderItem>();

            AddItemToCartCommand = new AddItemToCartCommand(this);

            RemoveItemFromCartCommand = new RemoveItemFromCartCommand(this);
            
            PlaceOrderCommand = new PlaceOrderCommand(this);
        }

        public void AddItem(OrderItem orderItem)
        {
            Items.Add(orderItem);

            OnPropertyChanged(nameof(TotalPrice));
        }

        public void RemoveItem(OrderItem orderItem)
        {
            var toppingsToRemove =
                Items.Where(q => q.ParentItemId == orderItem.Id);

            Items.Remove(orderItem);

            foreach (var topping in toppingsToRemove)
            {
                Items.Remove(topping);
            }

            OnPropertyChanged(nameof(TotalPrice));
        }

        public void PlaceOrder()
        {
            throw new System.NotImplementedException();
        }
    }
}