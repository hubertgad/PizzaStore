using PizzaStore.Domain.SeedWork;
using System;

namespace PizzaStore.Domain.Models.OrderAggregate
{
    public class Address : Entity
    {
        public string Street { get; private set; }

        public string Building { get; private set; }

        public ushort Unit { get; private set; }

        public string ZipCode { get; private set; }
        
        public string City { get; private set; }

        public Address()
        { }

        public Address(string street, string building, ushort unit, string zipCode, string city)
        {
            Street = street;
            Building = building;
            Unit = unit;
            ZipCode = zipCode;
            City = city;
        }

        public override bool Equals(object obj)
        {
            return obj is Address address &&
                   Street == address.Street &&
                   Building == address.Building &&
                   Unit == address.Unit &&
                   ZipCode == address.ZipCode &&
                   City == address.City;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, Building, Unit, ZipCode, City);
        }
    }
}