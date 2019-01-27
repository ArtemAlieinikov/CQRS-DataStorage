using Cassandra.Mapping;
using CQRSDataStorage.Domain.Entities;

namespace CQRSDataStorage.DAL.ColumnFamilyMapping
{
    public class ColumnFamilyMapping : Mappings
    {
        public ColumnFamilyMapping()
        {
            For<EmployeeEntity>()
                .KeyspaceName("employees")
                .TableName("employees_by_country_and_company")
                .Column(x => x.CountryName, n => n.WithName("country_name"))
                .Column(x => x.CompanyName, n => n.WithName("company_name"))
                .Column(x => x.EmployeeId, n => n.WithName("employee_id"))
                .Column(x => x.EmployeeName, n => n.WithName("employee_name"))
                .Column(x => x.EmployeeSurname, n => n.WithName("employee_surname"))
                .PartitionKey(x => x.CountryName, x => x.CompanyName)
                .ClusteringKey(x => x.CompanyName)
                .ClusteringKey(x => x.EmployeeId);
        }
    }
}