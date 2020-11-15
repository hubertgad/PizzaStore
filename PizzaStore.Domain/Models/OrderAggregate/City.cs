using PizzaStore.Domain.SeedWork;

namespace PizzaStore.Domain.Models.OrderAggregate
{
    public class City : Entity
    {
        public string Name { get; private set; }

        public City()
        { }

        public City(string name)
        {
            Name = name;
        }
    }
}