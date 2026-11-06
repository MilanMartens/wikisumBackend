using WikiSumBackend.Contracts.Chapter;

namespace WikiSumBackend.Contracts.Webpage
{
    public class WebpageDto
    {
        public string Url { get; set; } = string.Empty;

        public List<ChapterDto> Chapters { get; set; } = new();
    }

}
