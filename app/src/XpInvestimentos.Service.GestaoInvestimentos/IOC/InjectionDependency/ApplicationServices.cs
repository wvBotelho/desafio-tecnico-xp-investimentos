using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mail;
using Application.Services;
using Application.Usecases.FinancialProduct;
using Core.Interfaces;
using Core.Logger;
using Core.Validations;
using Infrastructure.Database.Context;
using Infrastructure.Database.Repository;
using Infrastructure.EmailDelivery;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IOC.InjectionDependency
{
    [ExcludeFromCodeCoverage]
    public static class ApplicationServices
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection service, IConfiguration configuration)
        {
            //repository
            service.AddSingleton<IMongoContext, MongoContext>();

            service.AddTransient<IMongoRepository, MongoRepository>();

            //application
            service.AddTransient<IFinancialProductUsecase, FinancialProductUsecase>();

            service.AddTransient<InvestimentValidation>();

            //core
            service.AddTransient<ILoggerGenerator>(_ =>
            {
                return new LoggerGenerator(Guid.NewGuid());
            });

            //service
            service.AddTransient<IEmailDeliveryService, EmailDeliveryService>();

            service.AddTransient<IEmailEngine, EmailEngine>();

            service.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));

            return service;
        }
    }
}