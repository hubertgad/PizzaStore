using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(int id);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);
    }
}