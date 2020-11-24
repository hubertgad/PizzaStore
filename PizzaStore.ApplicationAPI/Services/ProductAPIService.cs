using Newtonsoft.Json;
using PizzaStore.ApplicationAPI.Interfaces;
using PizzaStore.Domain.Models.Menu;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PizzaStore.ApplicationAPI.Services
{
    public class ProductAPIService : IProductAPIService
    {
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using WebClient client = new WebClient();
            
            string response = client.DownloadString("https://pizzastore.hubertgad.net/product");

            IEnumerable<Product> result = JsonConvert.DeserializeObject<IEnumerable<Product>>(response);

            return result;
        }
    }
}