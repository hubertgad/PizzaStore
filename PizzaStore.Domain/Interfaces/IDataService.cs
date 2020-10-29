using PizzaStore.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Interfaces
{
    public interface IDataService<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Create(T entity);

        Task<T> Update(int id, T entity);

        Task<bool> Delete(int id);
    }
}