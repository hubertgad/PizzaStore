using PizzaStore.Domain.Models.Menu;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.ApplicationApi.Interfaces
{
    public interface IProductApiService
    {
        public Task<IEnumerable<Product>> GetAllAsync();
    }
}