using WikiSumBackend.Contracts.Chapter;

namespace WikiSumBackend.Contracts.Webpage
{
    public class UpdateWebpageDto
    {
        public List<UpdateChapterDto> Chapters { get; set; } = new();
    }
}
