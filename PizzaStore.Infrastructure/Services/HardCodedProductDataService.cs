using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models.Menu;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Infrastructure.Services
{
    public class HardCodedProductDataService : IDataService<Product>
    {
        public async Task<IEnumerable<Product>> GetAll()
        {
            return new List<Product>
            {
                new Product { Symbol = "MARGA", Name = "Margaritta", Price = 20, ProductType = ProductType.Pizza },
                new Product { Symbol = "VEGET", Name = "Vegetariana", Price = 22, ProductType = ProductType.Pizza },
                new Product { Symbol = "TOSCC", Name = "Tosca", Price = 25, ProductType = ProductType.Pizza },
                new Product { Symbol = "VENEC", Name = "Venecia", Price = 25, ProductType = ProductType.Pizza },
                new Product { Symbol = "CHEES", Name = "Double cheese", Price = 2, ProductType = ProductType.PizzaTopping },
                new Product { Symbol = "SALAM", Name = "Salami", Price = 2, ProductType = ProductType.PizzaTopping },
                new Product { Symbol = "HAM", Name = "Ham", Price = 2, ProductType = ProductType.PizzaTopping },
                new Product { Symbol = "MUSHR", Name = "Mushrooms", Price = 2, ProductType = ProductType.PizzaTopping },
            };
        }
    }
}