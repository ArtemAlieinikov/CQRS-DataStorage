using System.Collections.Generic;
using CQRSDataStorage.Domain.Entities;
using CQRSDataStorage.Queries;
using CQRSDataStorage.Queries.Abstractions;
using CQRSDataStorage.Queries.Handlers;
using CQRSDataStorage.Queries.Queries;
using StructureMap;

namespace CQRSDataStorage.DependenciesCore.Registries
{
    public class QueriesRegistry : Registry
    {
        public QueriesRegistry()
        {
            For<IQueryDispatcher>().Use<QueryDispatcher>();

            For<IQueryHandler<GetAllEmployeesQuery, IEnumerable<EmployeeEntity>>>().Use<GetAllEmployeesQueryHandler>();
        }
    }
}