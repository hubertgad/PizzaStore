using PizzaStore.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Interfaces
{
    public interface IDataService<T> where T : IEntity
    {
        Task<IEnumerable<T>> GetAll();
    }
}