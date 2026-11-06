using AutoMapper;
using WikiSumBackend.Contracts.Translation;
using WikiSumBackend.Domain.Entiteiten;

namespace WikiSumBackend.API.MappingProfiles
{
    public class TranslationProfile : Profile
    {
        public TranslationProfile()
        {
            CreateMap<ChapterTranslation, TranslationDto>();
            CreateMap<CreateTranslationDto, ChapterTranslation>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Chapter, opt => opt.Ignore());
        }
    }
}
