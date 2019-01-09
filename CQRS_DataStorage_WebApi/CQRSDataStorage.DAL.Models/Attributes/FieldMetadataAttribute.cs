using System;
using CQRSDataStorage.DAL.TableModels.CassandraTypes;

namespace CQRSDataStorage.DAL.TableModels.Attributes
{
    public class FieldMetadataAttribute : Attribute
    {
        public readonly string FieldName;

        public readonly string FieldType;

        public readonly string KeyType;

        public FieldMetadataAttribute(CassandraDataTypes fieldType, string fieldName, CassandraKeyTypes keyType)
        {
            FieldName = fieldName;
            FieldType = Enum.GetName(fieldType.GetType(), fieldType);
            KeyType = Enum.GetName(keyType.GetType(), keyType);
        }
    }
}