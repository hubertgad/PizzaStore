using PizzaStore.WPF.State.Cart;

namespace PizzaStore.WPF.ViewModels
{
    public class CartViewModel : ViewModelBase
    {
        public ICart Cart { get; set; }

        public CartViewModel(ICart cart)
        {
            Cart = cart;
        }
    }
}