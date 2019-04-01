using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CQRSDataStorage.Domain.Entities;

namespace CQRSDataStorage.DAL.Abstractions.Repositories
{
    public interface IEmployeeRepository
    {
        void DeleteEmployee(EmployeeEntity employeeEntity);

        void AddEmployee(EmployeeEntity employeeEntity);

        IEnumerable<EmployeeEntity> GetEmployees();

        EmployeeEntity GetEmployee(Expression<Func<EmployeeEntity, bool>> filter);
    }
}