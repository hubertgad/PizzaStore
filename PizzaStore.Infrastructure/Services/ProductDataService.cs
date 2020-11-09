using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models.Menu;
using PizzaStore.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace PizzaStore.Infrastructure.Services
{
    class ProductDataService : IProductDataService
    {
        private readonly PizzaStoreDbContextFactory _contextFactory;

        public ProductDataService(PizzaStoreDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

       public IEnumerable<Product> GetAll()
        {
            using var context = _contextFactory.CreateDbContext();

            return context.Products
                .Include(q => q.Group)
                //.Include(q => q.Tax)
                .ToList();
        }
    }
}