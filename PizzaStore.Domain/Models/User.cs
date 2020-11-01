using PizzaStore.Domain.SeedWork;
using System;
using System.Collections.Generic;
using PizzaStore.Domain.Models.OrderAggregate;

namespace PizzaStore.Domain.Models
{
    public class User : Entity
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string PasswordHash { get; set; }

        public IEnumerable<Order> Orders { get; set; }

        public DateTime Joined { get; set; }

        public User()
        { }

        public User(string email, string name, string passwordHash)
        {
            Email = email;
            Name = name;
            PasswordHash = passwordHash;
            Orders = new List<Order>();
            Joined = DateTime.Now;
        }
    }
}