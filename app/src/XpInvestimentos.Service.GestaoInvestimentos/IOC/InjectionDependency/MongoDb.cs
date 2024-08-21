using System.Diagnostics.CodeAnalysis;
using Core.Interfaces;
using Core.MongoSchema;
using Infrastructure.Database.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IOC.InjectionDependency
{
    [ExcludeFromCodeCoverage]
    public static class MongoDb
    {
        public static IServiceCollection RegisterMongoDb(this IServiceCollection service, IConfiguration configuration)
        {
            BsonClassMaps.Register();

            service.Configure<MongoConnection>(configuration.GetSection("MongoConnection"));

            return service;
        }
    }
}