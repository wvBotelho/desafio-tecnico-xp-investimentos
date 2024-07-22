using System.Diagnostics.CodeAnalysis;

namespace Core.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    [ExcludeFromCodeCoverage]
    public class CollectionNameAttribute(string tableName) : Attribute
    {
        private readonly string _tableName = tableName ?? string.Empty;

        public string TableName
        {
            get
            {
                return _tableName;
            }
        }
    }
}