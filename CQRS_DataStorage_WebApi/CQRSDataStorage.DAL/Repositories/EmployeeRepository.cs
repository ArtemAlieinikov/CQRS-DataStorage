using System;
using Cassandra;
using CQRSDataStorage.DAL.Abstractions.Repositories;
using CQRSDataStorage.Domain.Entities;

namespace CQRSDataStorage.DAL.Repositories
{
    class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISession _session;

        public EmployeeRepository(ISession session, string tableKeySpace)
        {
            _session = session;
        }

        public void Add(EmployeeEntity employeeEntity)
        {
            
        }
    }
}
