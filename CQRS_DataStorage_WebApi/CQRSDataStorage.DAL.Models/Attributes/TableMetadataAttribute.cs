using System;

namespace CQRSDataStorage.DAL.TableModels.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableMetadataAttribute : Attribute
    {
        public readonly string KeySpaceName;

        public readonly string TableName;

        public TableMetadataAttribute(string tableName, string keySpaceName)
        {
            TableName = tableName;
            KeySpaceName = keySpaceName;
        }
    }
}