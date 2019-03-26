using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CQRSDataStorage.Domain.Entities;

namespace CQRSDataStorage.DAL.Abstractions.Repositories
{
    public interface IEmployeeRepository
    {
        Task DeleteEmployee(EmployeeEntity employeeEntity);

        Task AddEmployee(EmployeeEntity employeeEntity);

        IEnumerable<EmployeeEntity> GetEmployees();

        Task<EmployeeEntity> GetEmployee(Expression<Func<EmployeeEntity, bool>> filter);
    }
}