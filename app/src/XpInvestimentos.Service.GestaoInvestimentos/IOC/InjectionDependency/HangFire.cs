using System.Diagnostics.CodeAnalysis;
using Hangfire;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration.Strategies;
using Hangfire.Mongo.Migration.Strategies.Backup;
using Microsoft.Extensions.DependencyInjection;

namespace IOC.InjectionDependency
{
    [ExcludeFromCodeCoverage]
    public static class HangFire
    {
        public static IServiceCollection RegisterHangFire(this IServiceCollection service)
        {
            // GlobalConfiguration.Configuration
            //     .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            //     .UseSimpleAssemblyNameTypeSerializer()
            //     .UseRecommendedSerializerSettings()
            //     .UseNLogLogProvider()
            //     .UseMongoStorage("mongodb://localhost:27017/jobs", new MongoStorageOptions
            //     {
            //         MigrationOptions = new MongoMigrationOptions
            //         {
            //             MigrationStrategy = new DropMongoMigrationStrategy(),
            //             BackupStrategy = new NoneMongoBackupStrategy(),
            //         },
            //         CheckQueuedJobsStrategy = CheckQueuedJobsStrategy.TailNotificationsCollection
            //     });

            // Define a quantidade de retentativas aplicadas a um job com falha.
            // Por padrão serão 10, aqui estamos abaixando para duas com intervalo de 5 minutos
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 3, DelaysInSeconds = [300] });

            service.AddHangfireServer();

            service.AddHangfire(config =>
            {
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseNLogLogProvider()
                    .UseMongoStorage("mongodb://localhost:27017/jobs", new MongoStorageOptions
                    {
                        MigrationOptions = new MongoMigrationOptions
                        {
                            MigrationStrategy = new DropMongoMigrationStrategy(),
                            BackupStrategy = new NoneMongoBackupStrategy(),
                        },
                        CheckQueuedJobsStrategy = CheckQueuedJobsStrategy.TailNotificationsCollection
                    });
            });

            return service;
        }
    }
}