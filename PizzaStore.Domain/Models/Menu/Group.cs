using PizzaStore.Domain.SeedWork;

namespace PizzaStore.Domain.Models.Menu
{
    public class Group : Entity
    {
        public string Name { get; private set; }
        
        public bool IsTopping { get; private set; }

        public Group(string name, bool isTopping)
        {
            Name = name;
            IsTopping = isTopping;
        }
    }
}