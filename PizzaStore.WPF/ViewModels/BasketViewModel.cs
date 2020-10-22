using PizzaStore.WPF.State.Cart;

namespace PizzaStore.WPF.ViewModels
{
    public class BasketViewModel : ViewModelBase
    {
        public ICart Basket { get; set; }

        public BasketViewModel(ICart basket)
        {
            Basket = basket;
        }
    }
}