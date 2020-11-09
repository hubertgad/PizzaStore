using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models;
using PizzaStore.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Infrastructure.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly PizzaStoreDbContextFactory _contextFactory;

        public UserDataService (PizzaStoreDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<User> CreateAsync(User entity)
        {
            using var context = _contextFactory.CreateDbContext();

            EntityEntry<User> createdEntity = await context.Users.AddAsync(entity);
            await context.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            User entity = await context.Users.FirstOrDefaultAsync(q => q.Id == id);
            context.Users.Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }

        public Task<User> GetAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            return context.Users
                .Include(q => q.Orders)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using var context = _contextFactory.CreateDbContext();

            List<User> users = await context.Users.ToListAsync();

            return users;
        }

        public async Task<User> UpdateAsync(int id, User entity)
        {
            using var context = _contextFactory.CreateDbContext();

            entity.Id = id;
            context.Users.Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            using var context = _contextFactory.CreateDbContext();

            User user = await context.Users
                .Include(q => q.Orders)
                .FirstOrDefaultAsync(q => q.Email == email);

            return user;
        }
    }
}