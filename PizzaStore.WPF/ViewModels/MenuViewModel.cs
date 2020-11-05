using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Models.OrderAggregate;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;

namespace PizzaStore.WPF.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public CartViewModel Cart { get; }

        public IEnumerable<Product> Products { get; }

        public CollectionView Products2 { get; }

        public CollectionView Products3 { get; }

        public IEnumerable<Product> Toppings { get; }

        public IEnumerable<Product> Pizzas =>
            Products.Where(q => q.Group.Name == "Pizza");

        public IEnumerable<Product> PizzaToppings =>
            Products.Where(q => q.Group.Name == "PizzaTopping");

        public IEnumerable<Product> Mains =>
            Products.Where(q => q.Group.Name == "MainMeal");

        public IEnumerable<Product> MainToppings =>
            Products.Where(q => q.Group.Name == "MainMealTopping");

        public IEnumerable<Product> Soups =>
            Products.Where(q => q.Group.Name == "Soup");

        public IEnumerable<Product> Drinks =>
            Products.Where(q => q.Group.Name == "Drink");
        
        public ObservableCollection<OrderItem> Items => Cart.Items;

        public MenuViewModel(IProductDataService productDataService, CartViewModel cartViewModel)
        {
            Products = productDataService.GetAll();
            Cart = cartViewModel;

            Toppings = Products.Where(q => q.Group.IsTopping == true);

            Products2 = (CollectionView)CollectionViewSource.GetDefaultView(Products.Where(q => q.Group.IsTopping == false));
            
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Group.Name");
            Products2.GroupDescriptions.Add(groupDescription);

            var p3 = new ObservableCollection<Product3>();

            foreach (var product in Products.Where(q => !q.Group.IsTopping))
            {
                var tempProduct = new Product3 { Product = product };
                foreach (var topping in Products.Where(q => q.Group.IsTopping && q.Group.Name.Contains(product.Group.Name)))
                {
                    if (tempProduct.Toppings == null)
                    {
                        tempProduct.Toppings = new ObservableCollection<Product>();
                    }
                    tempProduct.Toppings.Add(topping);
                }
                p3.Add(tempProduct);
            }

            Products3 = (CollectionView)CollectionViewSource.GetDefaultView(p3);
            PropertyGroupDescription groupDescription3 = new PropertyGroupDescription("Product.Group.Name");
            Products3.GroupDescriptions.Add(groupDescription3);
        }

        class Product3
        {
            public Product Product { get; set; }
            public ObservableCollection<Product> Toppings { get; set; }
        }
    }
}