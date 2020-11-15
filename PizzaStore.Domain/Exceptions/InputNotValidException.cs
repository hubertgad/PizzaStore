using System;

namespace PizzaStore.Domain.Exceptions
{
    public class InputNotValidException : Exception
    {
        public InputNotValidException(string message) : base(message)
        { }

        public InputNotValidException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}