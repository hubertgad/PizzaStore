using PizzaStore.Domain.SeedWork;

namespace PizzaStore.Domain.Models
{
    public class Customer : Entity
    {
        public string Name { get; set; }

        public string Phone { get; set; }
        
        public string Email { get; set; }
        
        public string Address { get; set; }
    }
}