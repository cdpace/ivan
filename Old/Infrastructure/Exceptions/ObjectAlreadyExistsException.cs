using System;
namespace Infrastructure.Exceptions
{
    public class ObjectAlreadyExistsException : Exception 
    {
        public ObjectAlreadyExistsException(string message)
            :base(message)
        {

        }
    }
}
