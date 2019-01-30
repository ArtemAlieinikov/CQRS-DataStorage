using Cassandra;

namespace CQRSDataStorage.DAL.Abstractions
{
    public interface ISessionProxy
    {
        ISession Session { get; }
    }
}