using CQRSDataStorage.DAL;
using CQRSDataStorage.DAL.Abstractions;
using CQRSDataStorage.DAL.Abstractions.Repositories;
using CQRSDataStorage.DAL.Repositories;
using StructureMap;

namespace CQRSDataStorage.DependenciesCore.Registries
{
    public class DataAccessLayerRegistry : Registry
    {
        public DataAccessLayerRegistry()
        {
            For<ICassandraDataStorageInitializer>()
                .Use<CassandraDataStorageInitializer>()
                .Singleton();

            For<IEmployeeRepository>()
                .Use<EmployeeRepository>()
                .ContainerScoped();
        }    
    }
}