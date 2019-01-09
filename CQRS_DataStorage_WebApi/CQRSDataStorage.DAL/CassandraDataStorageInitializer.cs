using System;
using System.Collections.Generic;
using Cassandra;
using Cassandra.Data.Linq;
using Cassandra.Mapping;
using CQRSDataStorage.Domain.Entities;

namespace CQRSDataStorage.DAL
{
    public class CassandraDataStorageInitializer
    {
        public void Initialize(ISession session, List<Type> entity)
        {
            MappingConfiguration.Global.Define<ColumnFamilyMapping.ColumnFamilyMapping>();

            var tableToCreate = new Table<EmployeeEntity>(session);
            session.CreateKeyspaceIfNotExists(tableToCreate.KeyspaceName);

            tableToCreate.CreateIfNotExists();
        }
    }
}