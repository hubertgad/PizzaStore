using PizzaStore.Domain.Models.OrderAggregate;
using PizzaStore.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
    public class User : Entity
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string PasswordHash { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }

        public DateTime Joined { get; private set; }

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