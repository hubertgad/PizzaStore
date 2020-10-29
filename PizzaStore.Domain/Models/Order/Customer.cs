using System.Text;

namespace PizzaStore.Domain.Models.Order
{
    public class Customer
    {
        public string Name { get; private set; }

        public string Phone { get; private set; }

        public string Email { get; private set; }

        public Customer()
        { }

        public Customer(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: { Name }");
            sb.AppendLine($"Phone: { Phone}");
            sb.AppendLine($"E-mail address: { Email}");

            return sb.ToString();
        }
    }
}