using PizzaStore.Domain.SeedWork;
using System;

namespace PizzaStore.Domain.Models
{
    public class Pizza : Product
    {
        public PizzaAdditions Additions { get; set; }
    }

    [Flags]
    public enum PizzaAdditions
    {
        None = 0,
        DoubleCheese = 1,
        Salami = 2,
        Ham = 4,
        Mushrooms = 8
    }
}