using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Core.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace IOC.InjectionDependency
{
    [ExcludeFromCodeCoverage]
    public static class AutoMapper
    {
        public static IServiceCollection RegisterAutomapper(this IServiceCollection service)
        {
            MapperConfiguration config = new(MapperConfigure.Configure);

            IMapper mapper = config.CreateMapper();

            service.AddSingleton(mapper);

            return service;
        }
    }
}