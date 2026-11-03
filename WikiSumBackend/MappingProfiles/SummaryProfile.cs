using AutoMapper;
using WikiSumBackend.Contracts.Summary;
using WikiSumBackend.Domain.Entiteiten;

namespace WikiSumBackend.API.MappingProfiles
{
    public class SummaryProfile : Profile
    {
        public SummaryProfile()
        {
            CreateMap<Summary, SummaryDto>();

            CreateMap<CreateSummaryDto, Summary>();

            CreateMap<UpdateSummaryDto, Summary>();
        }
    }
}
