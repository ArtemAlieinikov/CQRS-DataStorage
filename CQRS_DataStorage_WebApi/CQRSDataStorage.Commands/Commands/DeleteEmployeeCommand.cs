using System;
using CQRSDataStorage.Commands.Abstractions;

namespace CQRSDataStorage.Commands.Commands
{
    public class DeleteEmployeeCommand : ICommand
    {
        public Guid EmployeeId { get; }

        public string CompanyName { get; }

        public string CountryName { get; }

        public DeleteEmployeeCommand(Guid employeeId, string companyName, string countryName)
        {
            EmployeeId = employeeId;
            CompanyName = companyName;
            CountryName = countryName;
        }
    }
}
