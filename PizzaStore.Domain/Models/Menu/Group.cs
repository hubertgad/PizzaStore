using PizzaStore.Domain.SeedWork;

namespace PizzaStore.Domain.Models.Menu
{
    public class Group : Entity
    {
        public string Name { get; set; }

        public bool IsTopping { get; set; }

        public Group()
        { }

        public Group(string name, bool isTopping)
        {
            Name = name;
            IsTopping = isTopping;
        }

        public Group(int id, string name, bool isTopping) 
            : this(name, isTopping)
        {
            Id = id;
        }
    }
}