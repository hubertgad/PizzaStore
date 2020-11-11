namespace PizzaStore.Domain.SeedWork
{
    public abstract class Entity : IEntity
    {
        public int Id { get; private set; }
    }
}