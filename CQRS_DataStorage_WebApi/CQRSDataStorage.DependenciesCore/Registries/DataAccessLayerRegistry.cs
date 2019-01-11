using CQRSDataStorage.DAL;
using CQRSDataStorage.DAL.Abstractions;
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
        }    
    }
}