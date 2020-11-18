using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Models.Menu;
using PizzaStore.Domain.Services;
using PizzaStore.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Infrastructure.Services
{
    class ProductDataService : IProductDataService
    {
        private readonly PizzaStoreDbContext _context;

        public ProductDataService(PizzaStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .ToListAsync();
        }
    }
}