using PizzaStore.Domain.SeedWork;

namespace PizzaStore.Domain.Models.OrderAggregate
{
    public class Address : Entity
    {
        public virtual City City { get; set; }

        public virtual ZipCode ZipCode { get; set; }

        public virtual Street Street { get; set; }

        public string Building { get; set; }

        public string Unit { get; set; }

        public Address()
        { }

        public Address(string street, string building, string unit, string zipCode, string city)
        {
            Street = new Street(street);
            Building = building;
            Unit = unit;
            ZipCode = new ZipCode(zipCode);
            City = new City(city);
        }
    }
}