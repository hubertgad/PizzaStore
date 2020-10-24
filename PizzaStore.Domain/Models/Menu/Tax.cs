using PizzaStore.Domain.SeedWork;

namespace PizzaStore.Domain.Models.Menu
{
    public class Tax : Entity
    {
        public string Name { get; private set; }

        public int Value { get; private set; }

        public Tax()
        {
        }

        public Tax(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}