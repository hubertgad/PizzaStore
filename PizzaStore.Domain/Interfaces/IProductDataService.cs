using PizzaStore.Domain.Models.Menu;
using System.Collections.Generic;

namespace PizzaStore.Domain.Interfaces
{
    public interface IProductDataService
    {
        public IEnumerable<Product> GetAll();
    }
}