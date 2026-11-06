using AutoMapper;
using WikiSumBackend.Contracts.Chapter;
using WikiSumBackend.Domain.Entiteiten;

namespace WikiSumBackend.API.MappingProfiles
{
    public class ChapterProfile : Profile
    {
        public ChapterProfile()
        {
            CreateMap<Chapter, ChapterDto>();

            CreateMap<CreateChapterDto, Chapter>();

            CreateMap<UpdateChapterDto, Chapter>();

        }
    }
}
