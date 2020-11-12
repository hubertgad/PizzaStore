using PizzaStore.Domain.Models.OrderAggregate;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Services.EmailServices
{
    public interface IEmailService
    {
        public Task SendAsync(Order order);
    }
}