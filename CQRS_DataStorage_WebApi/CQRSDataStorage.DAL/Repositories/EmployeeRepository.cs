using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Cassandra;
using Cassandra.Data.Linq;
using Cassandra.Mapping;
using CQRSDataStorage.DAL.Abstractions.Repositories;
using CQRSDataStorage.Domain.Entities;

namespace CQRSDataStorage.DAL.Repositories
{
    class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISession _session;
        private readonly IMapper _cassandraMapper;

        public EmployeeRepository(IMapper cassandraMapper, ISession session)
        {
            _cassandraMapper = cassandraMapper;
            _session = session;
        }

        public void DeleteEmployee(EmployeeEntity employeeEntity)
        {
            _cassandraMapper.Delete(employeeEntity);
        }

        public void AddEmployee(EmployeeEntity employeeEntity)
        {
            _cassandraMapper.Insert(employeeEntity);
        }

        public IEnumerable<EmployeeEntity> GetEmployees(Expression<Func<EmployeeEntity, bool>> filter)
        {
            var employees = GetTable()
                .Where(filter)
                .Execute();

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
