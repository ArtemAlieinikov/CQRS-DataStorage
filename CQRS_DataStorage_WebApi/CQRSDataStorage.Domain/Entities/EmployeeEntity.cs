using System;

namespace CQRSDataStorage.Domain.Entities
{
    public class EmployeeEntity : BaseDomainEntity
    {
        public string CompanyName { get; set; }

        public string CountryName { get; set; }

        public Guid EmployeeId { get; set; } = new Guid();

        public string EmployeeName { get; set; }

        public string EmployeeSurname { get; set; }
    }
}