using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.SeedWork;
using PizzaStore.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Infrastructure.Services
{
    public class GenericDataService<T> : IDataService<T> where T : Entity
    {
        protected readonly PizzaStoreDbContext _context;

        public GenericDataService(PizzaStoreDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            EntityEntry<T> createdEntity = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            T entity = await _context.Set<T>().FirstOrDefaultAsync(q => q.Id == id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public virtual Task<T> GetAsync(int id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}