using CQRSDataStorage.Commands.Abstractions;
using CQRSDataStorage.Domain.Entities;

namespace CQRSDataStorage.Commands.Commands
{
    public class AddEmployeeCommand : ICommand
    {
        public readonly EmployeeEntity _employeeToCreate;

        public AddEmployeeCommand(EmployeeEntity employeeEntity)
        {
            _employeeToCreate = employeeEntity;
        }
    }
}