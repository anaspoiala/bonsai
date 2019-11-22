using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Bonsai.Exceptions
{
    public class NotLoggedInException : Exception
    {
        public NotLoggedInException()
        {
        }

        public NotLoggedInException(string message) : base(message)
        {
        }

        public NotLoggedInException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotLoggedInException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
