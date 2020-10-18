using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models;
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
                new Product { Id = 1, Name = "Margaritta", Price = 20, Symbol = "MARG", Type = Type.Pizza },
                new Product { Id = 2, Name = "Vegetariana", Price = 22, Symbol = "VEGE", Type = Type.Pizza }
            };
        }
    }
}