using Cassandra;
using CQRSDataStorage.DAL.Abstractions;
using CQRSDataStorage.DAL.Abstractions.Strategies;

namespace CQRSDataStorage.DAL
{
    public class SessionProxy : ISessionProxy
    {
        public ISession Session { get; }

        public SessionProxy(ISession session, IInitializationStrategy initializationStrategy)
        {
            Session = session;

            initializationStrategy.Initialize(Session);
        }
    }
}