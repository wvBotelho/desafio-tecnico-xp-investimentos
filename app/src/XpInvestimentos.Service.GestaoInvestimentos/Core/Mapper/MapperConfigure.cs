using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Core.Dto;
using Core.Models;

namespace Core.Mapper
{
    [ExcludeFromCodeCoverage]
    public class MapperConfigure
    {
        public static void Configure(IMapperConfigurationExpression conf)
        {
            //InvestimentDocument -> InvestimentDto
            conf.CreateMap<InvestimentDocument, InvestmentDto>();

            //InvestimentDto -> InvestimentDocument
            conf.CreateMap<InvestmentDto, InvestimentDocument>();
        }
    }
}