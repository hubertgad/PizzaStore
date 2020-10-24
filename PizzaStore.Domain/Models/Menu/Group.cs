using PizzaStore.Domain.SeedWork;

namespace PizzaStore.Domain.Models.Menu
{
    public class Group : Entity
    {
        public string Name { get; set; }
        
        public bool IsTopping { get; set; }
    }
}