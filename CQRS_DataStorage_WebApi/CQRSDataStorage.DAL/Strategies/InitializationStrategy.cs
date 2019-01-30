using Cassandra;
using Cassandra.Data.Linq;
using Cassandra.Mapping;
using CQRSDataStorage.DAL.Abstractions.Strategies;
using CQRSDataStorage.Domain.Entities;

namespace CQRSDataStorage.DAL.Strategies
{
    public class InitializationStrategy : IInitializationStrategy
    {
        public void Initialize(ISession session)
        {
            MappingConfiguration.Global.Define<ColumnFamilyMapping.ColumnFamilyMapping>();

            var tableToCreate = new Table<EmployeeEntity>(session);
            session.CreateKeyspaceIfNotExists(tableToCreate.KeyspaceName);

            tableToCreate.CreateIfNotExists();
        }
    }
}