using WikiSumBackend.Contracts.Chapter;

namespace WikiSumBackend.Contracts.Webpage
{
    public class CreateWebpageDto
    {
        public string Url { get; set; } = string.Empty;
        public List<CreateChapterDto> Chapters { get; set; } = new();
    }
}
