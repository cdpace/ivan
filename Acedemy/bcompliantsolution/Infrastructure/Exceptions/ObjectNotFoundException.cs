using System;
namespace Infrastructure.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public Guid CorrelationId { get; }

        public ObjectNotFoundException(string message, Guid correlationId)
            :base(message)
        {
            CorrelationId = correlationId;
        }
    }
}
