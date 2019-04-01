using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cassandra;
using Cassandra.Data.Linq;
using Cassandra.Mapping;
using CQRSDataStorage.DAL.Abstractions;
using CQRSDataStorage.DAL.Abstractions.Repositories;
using CQRSDataStorage.Domain.Entities;

namespace CQRSDataStorage.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISession _session;
        private readonly IMapper _cassandraMapper;

        public EmployeeRepository(ISessionProxy sessionProxy, IMapper cassandraMapper)
        {
            _session = sessionProxy.Session;
            _cassandraMapper = cassandraMapper;
        }

        public void DeleteEmployee(EmployeeEntity employeeEntity)
        {
            _cassandraMapper.DeleteAsync(employeeEntity);
        }

        public void AddEmployee(EmployeeEntity employeeEntity)
        {
            _cassandraMapper.InsertAsync(employeeEntity);
        }

        public IEnumerable<EmployeeEntity> GetEmployees()
        {
            var employees = GetTable().Execute();

            return employees;
        }

        public EmployeeEntity GetEmployee(Expression<Func<EmployeeEntity, bool>> filter)
        {
            var employees = GetTable()
                .First(filter)
                .Execute();

            return employees;
        }

        private Table<EmployeeEntity> GetTable()
        {
            var table = new Table<EmployeeEntity>(_session);

            return table;
        }
    }
}
