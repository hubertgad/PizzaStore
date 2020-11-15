using PizzaStore.Domain.SeedWork;

namespace PizzaStore.Domain.Models.OrderAggregate
{
    public class Street : Entity
    {
        public string Name { get; private set; }

        public Street()
        { }
        
        public Street(string name)
        {
            Name = name;
        }
    }
}