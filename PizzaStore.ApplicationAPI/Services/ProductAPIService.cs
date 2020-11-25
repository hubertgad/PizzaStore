using PizzaStore.ApplicationApi.Interfaces;
using PizzaStore.Domain.Models.Menu;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaStore.ApplicationApi.Services
{
    public class ProductApiService : IProductApiService
    {
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            string url = "https://pizzastore.hubertgad.net/product";
            using HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Product> result = await response.Content.ReadAsAsync<List<Product>>();
                return result;
            }

            return null;
        }
    }
}