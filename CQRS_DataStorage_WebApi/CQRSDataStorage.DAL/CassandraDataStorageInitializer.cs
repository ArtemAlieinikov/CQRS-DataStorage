using Cassandra;
using Cassandra.Data.Linq;
using Cassandra.Mapping;
using CQRSDataStorage.DAL.ColumnFamilyMapping;
using CQRSDataStorage.DAL.TableModels.TablesDefenitions;
using CQRSDataStorage.Domain.Entities;

namespace CQRSDataStorage.DAL
{
    public class CassandraDataStorageInitializer
    {
        private ISession _initializeSession;

        public void Initialize(string[] contactPoints, CommonCassandraTableEntity tableEntityToInspect, EmployeeEntity entity)
        {
            MappingConfiguration.Global.Define<EmployeeColumnFamilyMapping>();

            _initializeSession = Cluster.Builder()
                .AddContactPoints(contactPoints)
                .Build()
                .Connect();

            var tableToCreate = new Table<EmployeeEntity>(_initializeSession);
            _initializeSession.CreateKeyspaceIfNotExists(tableToCreate.KeyspaceName);

            tableToCreate.CreateIfNotExists();
        }
    }
}