using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSDataStorage.DAL.Abstractions.Repositories;
using CQRSDataStorage.Domain.Entities;
using CQRSDataStorage.Queries.Abstractions;
using CQRSDataStorage.Queries.Queries;

namespace CQRSDataStorage.Queries.Handlers
{
    public class GetAllEmployeesQueryHandler : IQueryHandler<GetAllEmployeesQuery, IEnumerable<EmployeeEntity>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeEntity> Execute(GetAllEmployeesQuery query)
        {
            var employees = _employeeRepository.GetEmployees(x => true);

            return employees;
        }
    }
}