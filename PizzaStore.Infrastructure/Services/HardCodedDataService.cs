using PizzaStore.Domain.Interfaces;
using PizzaStore.Domain.Models;
using PizzaStore.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Infrastructure.Services
{
    public class HardCodedDataService<T> : IDataService<T> where T : Entity
    {
        public async Task<IEnumerable<T>> GetAll()
        {
            if (typeof(T) == typeof(Product))
            {
                return (IEnumerable<T>)GetProducts();
            }

            else throw new NotImplementedException();
        }

        private IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Margaritta", Price = 20, Symbol = "MARG", Type = Domain.Models.Type.Pizza },
                new Product { Id = 2, Name = "Vegetariana", Price = 22, Symbol = "VEGE", Type = Domain.Models.Type.Pizza }
            };
        }
    }
}