using PizzaStore.Domain.Models.Menu;
using System.Collections.Generic;

namespace PizzaStore.Domain.Services
{
    public interface IProductDataService
    {
        public IEnumerable<Product> GetAll();
    }
}