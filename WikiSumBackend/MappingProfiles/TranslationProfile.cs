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
        }
    }
}
