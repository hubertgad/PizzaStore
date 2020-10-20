using PizzaStore.WPF.State.Basket;

namespace PizzaStore.WPF.ViewModels
{
    public class BasketViewModel : ViewModelBase
    {
        public IBasket Basket { get; set; }

        public BasketViewModel(IBasket basket)
        {
            Basket = basket;
        }
    }
}