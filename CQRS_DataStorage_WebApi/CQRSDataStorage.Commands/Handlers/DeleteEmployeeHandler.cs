using System;
using CQRSDataStorage.Commands.Abstractions;
using CQRSDataStorage.Commands.Commands;
using CQRSDataStorage.DAL.Abstractions.Repositories;
using CQRSDataStorage.Domain.Entities;

namespace CQRSDataStorage.Commands.Handlers
{
    public class DeleteEmployeeHandler : ICommandHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Execute(DeleteEmployeeCommand command)
        {
            try
            {
                var entityToDelete = new EmployeeEntity
                {
                    EmployeeId = command.EmployeeId,
                    CompanyName = command.CompanyName,
                    CountryName = command.CountryName
                };

                _employeeRepository.DeleteEmployee(entityToDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}