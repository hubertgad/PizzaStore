using PizzaStore.Domain.Models.Menu;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.ApplicationAPI.Interfaces
{
    public interface IProductAPIService
    {
        public Task<IEnumerable<Product>> GetAllAsync();
    }
}