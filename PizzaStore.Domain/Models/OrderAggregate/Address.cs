using PizzaStore.Domain.SeedWork;
using System;

namespace PizzaStore.Domain.Models.OrderAggregate
{
    public class Address : Entity
    {
        public string Street { get; private set; }

        public string Building { get; private set; }

        public string Unit { get; private set; }

        public Address()
        { }

        public Address(string street, string houseNumber, string unit)
        {
            Street = street;
            Building = houseNumber;
            Unit = unit;
        }

        public override bool Equals(object obj)
        {
            return obj is Address address &&
                   Street.Equals(address.Street) &&
                   Building.Equals(address.Building) &&
                   Unit.Equals(address.Unit);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, Building, Unit);
        }
    }
}