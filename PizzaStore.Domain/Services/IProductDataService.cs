using PizzaStore.Domain.Models.Menu;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Services
{
    public interface IProductDataService
    {
        public Task<IEnumerable<Product>> GetAllAsync();
    }
}