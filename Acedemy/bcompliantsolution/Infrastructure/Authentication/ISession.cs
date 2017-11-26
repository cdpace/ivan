using System;
namespace Infrastructure.Authentication
{
    public interface ISession
    {
        void InitializeSession();

        //Properties
        Guid CorrelationId { get; }
    }
}
