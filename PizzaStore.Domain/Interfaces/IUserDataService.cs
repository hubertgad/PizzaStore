using PizzaStore.Domain.Models;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Interfaces
{
    public interface IUserDataService : IDataService<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}