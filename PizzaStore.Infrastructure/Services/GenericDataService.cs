using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.SeedWork;
using PizzaStore.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.Infrastructure.Services
{
    public class GenericDataService<T> : IDataService<T> where T : Entity
    {
        private readonly PizzaStoreDbContextFactory _contextFactory;

        public GenericDataService(PizzaStoreDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> CreateAsync(T entity)
        {
            using var context = _contextFactory.CreateDbContext();

            EntityEntry<T> createdEntity = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            T entity = await context.Set<T>().FirstOrDefaultAsync(q => q.Id == id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }

        public Task<T> GetAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            return context.Set<T>().FirstOrDefaultAsync(q => q.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            using var context = _contextFactory.CreateDbContext();

            return context.Set<T>().ToList();
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            using var context = _contextFactory.CreateDbContext();

            entity.Id = id;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}