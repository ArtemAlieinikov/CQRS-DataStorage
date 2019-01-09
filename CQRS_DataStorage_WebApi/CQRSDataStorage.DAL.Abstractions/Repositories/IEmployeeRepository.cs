using CQRSDataStorage.Domain.Entities;

namespace CQRSDataStorage.DAL.Abstractions.Repositories
{
    public interface IEmployeeRepository
    {
        void Add(EmployeeEntity employeeEntity);
    }
}