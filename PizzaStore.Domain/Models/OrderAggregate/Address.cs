﻿using System.Text;

namespace PizzaStore.Domain.Models.OrderAggregate
{
    public class Address
    {
        public string Street { get; private set; }

        public string HouseNumber { get; private set; }

        public string HouseUnitNumber { get; private set; }

        public Address()
        { }

        public Address(string street, string houseNumber, string houseUnitNumber)
        {
            Street = street;
            HouseNumber = houseNumber;
            HouseUnitNumber = houseUnitNumber;
        }

        public override string ToString()
        {
            var address = new StringBuilder($"{ Street } { HouseNumber }");
            
            if (!string.IsNullOrEmpty(HouseUnitNumber))
            {
                address.Append($"/{ HouseUnitNumber }");
            }

            return address.ToString();
        }
    }
}