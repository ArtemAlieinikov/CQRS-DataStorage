using System.Collections.Generic;
using CQRSDataStorage.Domain.Entities;
using CQRSDataStorage.Queries.Abstractions;

namespace CQRSDataStorage.Queries.Queries
{
    public class GetAllEmployeesQuery : IQuery<IEnumerable<EmployeeEntity>>
    { }
}