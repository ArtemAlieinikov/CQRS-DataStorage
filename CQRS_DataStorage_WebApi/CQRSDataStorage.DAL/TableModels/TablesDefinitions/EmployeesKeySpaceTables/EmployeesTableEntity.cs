using System;
using Cassandra.Mapping.Attributes;
using CQRSDataStorage.DAL.TableModels.Attributes;
using CQRSDataStorage.DAL.TableModels.CassandraTypes;
using CQRSDataStorage.DAL.TableModels.TablesDefenitions;

namespace CQRSDataStorage.DAL.TableModels.TablesDefinitions.EmployeesKeySpaceTables
{
    [TableMetadata("employees", "employees")]
    [Table("employees.employees")]
    public class EmployeesTableEntity : CommonCassandraTableEntity
    {
        [FieldMetadata(CassandraDataTypes.text, "company_name", CassandraKeyTypes.PartitionKey)]
        [PartitionKey]
        [Column("company_name")]
        public string CompanyName { get; set; }

        [FieldMetadata(CassandraDataTypes.text, "country_name", CassandraKeyTypes.PartitionKey)]
        [PartitionKey]
        [Column("country_name")]
        public string CountryName { get; set; }

        [FieldMetadata(CassandraDataTypes.uuid, "employee_id", CassandraKeyTypes.ClusteringKey)]
        [ClusteringKey]
        [Column("employee_id")]
        public Guid EmployeeId { get; set; }

        [FieldMetadata(CassandraDataTypes.text, "employee_name", CassandraKeyTypes.NotKeyField)]
        [Column("employee_name")]
        public string EmployeeName { get; set; }

        [FieldMetadata(CassandraDataTypes.text, "Employee_surname", CassandraKeyTypes.NotKeyField)]
        [Column("employee_surname")]
        public string EmployeeSurname { get; set; }
    }
}