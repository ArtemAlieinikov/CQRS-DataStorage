using Cassandra;
using CQRSDataStorage.DAL.Abstractions;

namespace CQRSDataStorage.DAL
{
    public class SessionProxy :  ISessionProxy
    {
        private readonly ISession _session;

        public SessionProxy(ISession session)
        {
            _session = session;
        }

        public RowSet Execute(IStatement statement)
        {
            return _session.Execute(statement);
        }
    }
}