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
        private readonly PizzaStoreDbContext _context;

        public UserDataService(PizzaStoreDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User entity)
        {
            EntityEntry<User> createdEntity = await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            User entity = await _context.Users.FirstOrDefaultAsync(q => q.Id == id);
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public Task<User> GetAsync(int id)
        {
            return _context.Users
                .Include(q => q.Orders)
                .ThenInclude(q => q.Address)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            List<User> users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User> UpdateAsync(int id, User entity)
        {
            entity.Id = id;
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            User user = await _context.Users
                .Include(q => q.Orders)
                .ThenInclude(q => q.Address)
                .FirstOrDefaultAsync(q => q.Email == email);

            return user;
        }
    }
}