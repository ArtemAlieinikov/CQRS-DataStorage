using Cassandra;

namespace CQRSDataStorage.DAL.Abstractions.Strategies
{
    public interface IInitializationStrategy
    {
        void Initialize(ISession session);
    }
}
