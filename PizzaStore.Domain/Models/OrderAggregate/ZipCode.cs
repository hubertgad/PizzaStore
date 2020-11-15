using PizzaStore.Domain.SeedWork;

namespace PizzaStore.Domain.Models.OrderAggregate
{
    public class ZipCode : Entity
    {
        public string Code { get; private set; }

        public ZipCode()
        { }

        public ZipCode(string code)
        {
            Code = code;
        }
    }
}