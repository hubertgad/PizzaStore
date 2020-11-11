using System;
using System.Runtime.Serialization;

namespace PizzaStore.Domain.Exceptions
{
    public class CannotSendEmailException : Exception
    {
        public CannotSendEmailException()
        {
        }

        public CannotSendEmailException(string message) : base(message)
        {
        }

        public CannotSendEmailException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CannotSendEmailException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}