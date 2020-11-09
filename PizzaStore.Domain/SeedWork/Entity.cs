using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Domain.SeedWork
{
    public class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}