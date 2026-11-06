using AutoMapper;
using WikiSumBackend.Contracts.Chapter;
using WikiSumBackend.Contracts.Summary;
using WikiSumBackend.Contracts.Translation;
using WikiSumBackend.Contracts.Webpage;
using WikiSumBackend.Domain.Entiteiten;

namespace WikiSumBackend.API.MappingProfiles
{
    public class WebpageProfile : Profile
    {
        public WebpageProfile()
        {
            CreateMap<Webpage, WebpageDto>();

            CreateMap<UpdateWebpageDto, Webpage>();

            CreateMap<CreateWebpageDto, Webpage>();

            CreateMap<CreateWebpageDto, Webpage>();

            CreateMap<CreateChapterDto, Chapter>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Webpage, opt => opt.Ignore());

            CreateMap<CreateTranslationDto, ChapterTranslation>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Chapter, opt => opt.Ignore());

            CreateMap<CreateSummaryDto, Summary>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ChapterTranslation, opt => opt.Ignore());

            CreateMap<ChapterTranslation, TranslationDto>();
        }
    }
}
