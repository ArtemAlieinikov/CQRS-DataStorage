using Cassandra.Mapping;
using CQRSDataStorage.Domain.Entities;

namespace CQRSDataStorage.DAL.ColumnFamilyMapping
{
    public class ColumnFamilyMapping : Mappings
    {
        private const string EmployeeKeySpaceName = "employees";

        private const string EmployeeTableName = "employees_by_country_and_company";

        private const string EmployeeCountryNameColumnName = "country_name";
        private const string EmployeeCompanyNameColumnName = "company_name";
        private const string EmployeeEmployeeIdColumnName = "employee_id";
        private const string EmployeeEmployeeNameColumnName = "employee_name";
        private const string EmployeeEmployeeSurnameColumnName = "employee_surname";

        public ColumnFamilyMapping()
        {
            For<EmployeeEntity>()
                .KeyspaceName(EmployeeKeySpaceName)
                .TableName(EmployeeTableName)
                .Column(x => x.CountryName, n => n.WithName(EmployeeCountryNameColumnName))
                .Column(x => x.CompanyName, n => n.WithName(EmployeeCompanyNameColumnName))
                .Column(x => x.EmployeeId, n => n.WithName(EmployeeEmployeeIdColumnName))
                .Column(x => x.EmployeeName, n => n.WithName(EmployeeEmployeeNameColumnName))
                .Column(x => x.EmployeeSurname, n => n.WithName(EmployeeEmployeeSurnameColumnName))
                .PartitionKey(x => x.CountryName)
                .ClusteringKey(EmployeeCompanyNameColumnName, EmployeeEmployeeIdColumnName);
        }
    }
}