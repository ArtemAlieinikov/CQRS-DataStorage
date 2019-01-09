using System;
using System.Collections.Generic;
using System.Linq;
using CQRSDataStorage.DAL.TableModels.Attributes;
using CQRSDataStorage.DAL.TableModels.KeySpaceTables;

namespace CQRSDataStorage.DAL.TableModels.Extensions
{
    public static class CommonCassandraTableExtension
    {
        public static string GetKeySpaceName(this CommonCassandraTableEntity cassandraTableEntity)
        {
            return GetTableMetadataAttributesValue(cassandraTableEntity, x => x.First().KeySpaceName, "Key space for this table is not set");
        }

        public static string GetTableName(this CommonCassandraTableEntity cassandraTableEntity)
        {
            return GetTableMetadataAttributesValue(cassandraTableEntity, x => x.First().TableName, "Table name is not set");
        }

        public static IReadOnlyCollection<(string fieldName, string fieldType, string keyType)> GetPropertyMetadata(this CommonCassandraTableEntity cassandraTableEntity)
        {
            var result = new List<(string fieldName, string fieldType, string keyType)>();
            var cassandraTypeToInspect = cassandraTableEntity.GetType();

            var propertiesToInspect = cassandraTypeToInspect.GetProperties();

            foreach (var property in propertiesToInspect)
            {
                if (property.GetCustomAttributes(typeof(FieldMetadataAttribute), true) is FieldMetadataAttribute[] attributes && attributes.Any())
                {
                    var attribute = attributes.First();

                    result.Add((attribute.FieldName, attribute.FieldType, attribute.KeyType));
                }
            }

            return result;
        }

        private static string GetTableMetadataAttributesValue(
            CommonCassandraTableEntity tableEntity, 
            Func<TableMetadataAttribute[], string> propRetrievingCallBack,
            string errorMessage)
        {
            var tableType = tableEntity.GetType();

            if (tableType.GetCustomAttributes(typeof(TableMetadataAttribute), false) is TableMetadataAttribute[] attributes && attributes.Any())
            {
                return propRetrievingCallBack(attributes);
            }

            throw new ArgumentException($"{typeof(TableMetadataAttribute)} - {errorMessage}");
        }
    }
}