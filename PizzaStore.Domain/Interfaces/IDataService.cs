using PizzaStore.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Interfaces
{
    public interface IDataService<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(int id);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(int id, T entity);

        Task<bool> DeleteAsync(int id);
    }
}