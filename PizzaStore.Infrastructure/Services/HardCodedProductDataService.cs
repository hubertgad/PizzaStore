using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Infrastructure.Services
{
    public class HardCodedProductDataService : IDataService<Pizza>
    {
        public async Task<IEnumerable<Pizza>> GetAll()
        {
            return new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Margaritta", Price = 20, Symbol = "MARG", Additions = PizzaAdditions.None  },
                new Pizza { Id = 2, Name = "Vegetariana", Price = 22, Symbol = "VEGE", Additions = PizzaAdditions.None },
                new Pizza { Id = 3, Name = "Tosca", Price = 25, Symbol = "TOSC", Additions = PizzaAdditions.None },
                new Pizza { Id = 4, Name = "Venecia", Price = 25, Symbol = "VENE", Additions = PizzaAdditions.None }
            };
        }
    }
}