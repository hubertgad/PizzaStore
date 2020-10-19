using PizzaStore.Domain.SeedWork;

namespace PizzaStore.Domain.Models
{
    public class ProductOrder : Entity
    {
        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }
    }
}