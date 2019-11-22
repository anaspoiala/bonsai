using System;
using System.Runtime.Serialization;

namespace Bonsai.Exceptions
{
    public class PantryNotFoundException : Exception
    {
        public PantryNotFoundException()
        {
        }

        public PantryNotFoundException(string message) : base(message)
        {
        }

        public PantryNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PantryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
