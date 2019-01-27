using Cassandra;
using Cassandra.Data.Linq;
using Cassandra.Mapping;
using CQRSDataStorage.Domain.Entities;
using CQRSDataStorage.DAL.Abstractions;

namespace CQRSDataStorage.DAL
{
    public class CassandraDataStorageInitializer : ICassandraDataStorageInitializer
    {
        public CassandraDataStorageInitializer(ISession session)
        {
            Initialize(session);
        }

        private void Initialize(ISession session)
        {
            MappingConfiguration.Global.Define<ColumnFamilyMapping.ColumnFamilyMapping>();

            var tableToCreate = new Table<EmployeeEntity>(session);
            session.CreateKeyspaceIfNotExists(tableToCreate.KeyspaceName);

            tableToCreate.CreateIfNotExists();
        }
    }
}