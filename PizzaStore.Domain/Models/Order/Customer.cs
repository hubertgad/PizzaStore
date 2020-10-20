using PizzaStore.Domain.SeedWork;

namespace PizzaStore.Domain.Models.Order
{
    public class Customer : Entity
    {
        public string Name { get; set; }

        public string Phone { get; set; }
        
        public string Email { get; set; }
    }
}