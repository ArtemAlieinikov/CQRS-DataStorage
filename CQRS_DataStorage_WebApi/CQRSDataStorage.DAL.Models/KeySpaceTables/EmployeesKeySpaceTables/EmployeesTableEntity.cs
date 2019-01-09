using CQRSDataStorage.DAL.TableModels.Attributes;
using CQRSDataStorage.DAL.TableModels.CassandraTypes;

namespace CQRSDataStorage.DAL.TableModels.KeySpaceTables.EmployeesKeySpaceTables
{
    [TableMetadata("employees", "employees")]
    public class EmployeesTableEntity : CommonCassandraTableEntity
    {
        [FieldMetadata(CassandraDataTypes.text, "companyName", CassandraKeyTypes.PartitionKey)]
        public string CompanyName { get; set; }

        [FieldMetadata(CassandraDataTypes.text, "countryName", CassandraKeyTypes.PartitionKey)]
        public string CountryName { get; set; }

        [FieldMetadata(CassandraDataTypes.uuid, "employeeId", CassandraKeyTypes.ClusteringKey)]
        public string EmployeeId { get; set; }

        [FieldMetadata(CassandraDataTypes.text, "employeeName", CassandraKeyTypes.NotKeyField)]
        public string EmployeeName { get; set; }

        [FieldMetadata(CassandraDataTypes.text, "employeeSurname", CassandraKeyTypes.NotKeyField)]
        public string EmployeeSurname { get; set; }
    }
}