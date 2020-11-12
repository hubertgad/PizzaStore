using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Services;
using PizzaStore.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace PizzaStore.Infrastructure.Services
{
    class ProductDataService : IProductDataService
    {
        private readonly PizzaStoreDbContext _context;

        public ProductDataService(PizzaStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products
                .Include(q => q.Group)
                .ToList();
        }
    }
}