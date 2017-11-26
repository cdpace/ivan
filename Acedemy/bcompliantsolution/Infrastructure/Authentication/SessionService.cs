using System;
namespace Infrastructure.Authentication
{
    public class SessionService : ISession
    {
        public SessionService()
        {

        }

        public Guid CorrelationId { get; private set; }

        public void InitializeSession()
        {
            CorrelationId = Guid.NewGuid();
        }
    }
}
