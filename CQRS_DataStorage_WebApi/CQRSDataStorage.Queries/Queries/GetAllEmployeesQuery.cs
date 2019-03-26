using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSDataStorage.Domain.Entities;
using CQRSDataStorage.Queries.Abstractions;

namespace CQRSDataStorage.Queries.Queries
{
    public class GetAllEmployeesQuery : IQuery<IEnumerable<EmployeeEntity>>
    { }
}