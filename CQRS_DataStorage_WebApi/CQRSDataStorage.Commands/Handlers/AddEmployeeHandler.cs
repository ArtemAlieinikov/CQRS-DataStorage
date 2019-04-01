using System;
using CQRSDataStorage.Commands.Abstractions;
using CQRSDataStorage.Commands.Commands;
using CQRSDataStorage.DAL.Abstractions.Repositories;

namespace CQRSDataStorage.Commands.Handlers
{
    public class AddEmployeeHandler : ICommandHandler<AddEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public AddEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Execute(AddEmployeeCommand command)
        {
            var employeeToCreate = command._employeeToCreate;

            employeeToCreate.EmployeeId = Guid.NewGuid();

            _employeeRepository.AddEmployee(employeeToCreate);
        }
    }
}