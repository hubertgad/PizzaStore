using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models.Menu;
using PizzaStore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.Infrastructure.Services
{
    class ProductDataService : IDataService<Product>
    {
        private readonly PizzaStoreDbContextFactory _contextFactory;

        public ProductDataService(PizzaStoreDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Task<Product> CreateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            return context.Products.FirstOrDefaultAsync(q => q.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            using var context = _contextFactory.CreateDbContext();

            return context.Products
                .Include(q => q.Group)
                .Include(q => q.Tax)
                .ToList();
        }

        public Task<Product> UpdateAsync(int id, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}