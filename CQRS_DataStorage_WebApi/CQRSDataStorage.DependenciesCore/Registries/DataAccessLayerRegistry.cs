using CQRSDataStorage.DAL;
using CQRSDataStorage.DAL.Abstractions;
using CQRSDataStorage.DAL.Abstractions.Repositories;
using CQRSDataStorage.DAL.Abstractions.Strategies;
using CQRSDataStorage.DAL.Repositories;
using CQRSDataStorage.DAL.Strategies;
using StructureMap;

namespace CQRSDataStorage.DependenciesCore.Registries
{
    public class DataAccessLayerRegistry : Registry
    {
        public DataAccessLayerRegistry()
        {
            For<ISessionProxy>()
                .Use<SessionProxy>()
                .Singleton();

            For<IInitializationStrategy>()
                .Use<InitializationStrategy>()
                .Singleton();

            For<IEmployeeRepository>()
                .Use<EmployeeRepository>()
                .ContainerScoped();
        }    
    }
}