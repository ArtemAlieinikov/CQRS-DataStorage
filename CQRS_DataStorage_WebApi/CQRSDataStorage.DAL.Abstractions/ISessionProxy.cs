using Cassandra;

namespace CQRSDataStorage.DAL.Abstractions
{
    public interface ISessionProxy
    {
        RowSet Execute(IStatement statement);
    }
}