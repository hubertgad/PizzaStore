using PizzaStore.Domain.Models.OrderAggregate;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Interfaces
{
	public interface IEmailService
	{
		public Task SendAsync(Order order);
	}
}