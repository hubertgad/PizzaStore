using PizzaStore.Domain.Models;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Services
{
    public interface IUserDataService : IDataService<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}