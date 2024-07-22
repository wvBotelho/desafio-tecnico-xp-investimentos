using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Database.Context
{
    [ExcludeFromCodeCoverage]
    public class MongoConnection
    {
        public string ConnectionString { get; set; } = string.Empty;

        public string Database { get; set; } = string.Empty;

        public bool IsSSL { get; set; }
    }
}