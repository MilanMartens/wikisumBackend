using AutoMapper;
using WikiSumBackend.Contracts.Webpage;
using WikiSumBackend.Domain.Entiteiten;

namespace WikiSumBackend.API.MappingProfiles
{
    public class WebpageProfile : Profile
    {
        public WebpageProfile()
        {
            CreateMap<Webpage, WebpageDto>();

            CreateMap<CreateWebpageDto, Webpage>();

            CreateMap<UpdateWebpageDto, Webpage>();
        }
    }
}
