using CQRSDataStorage.DAL.Abstractions;
using CQRSDataStorage.DAL.Abstractions.Repositories;
using CQRSDataStorage.Domain.Entities;

namespace CQRSDataStorage.DAL.Repositories
{
    class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISessionProxy _sessionProxy;

        public EmployeeRepository(ISessionProxy sessionProxy)
        {
            _sessionProxy = sessionProxy;
        }

        public void Add(EmployeeEntity employeeEntity)
        {
            
        }
    }
}
