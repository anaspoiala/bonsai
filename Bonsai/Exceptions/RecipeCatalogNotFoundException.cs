using System;
using System.Runtime.Serialization;

namespace Bonsai.Exceptions
{
    public class RecipeCatalogNotFoundException : Exception
    {
        public RecipeCatalogNotFoundException()
        {
        }

        public RecipeCatalogNotFoundException(string message) : base(message)
        {
        }

        public RecipeCatalogNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RecipeCatalogNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}