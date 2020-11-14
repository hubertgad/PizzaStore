using PizzaStore.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Services
{
    public interface IUserDataService
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetAsync(int id);

        Task<User> CreateAsync(User entity);

        Task<User> UpdateAsync(User entity);

        Task<bool> DeleteAsync(User entity);

        Task<User> GetByEmailAsync(string email);
    }
}