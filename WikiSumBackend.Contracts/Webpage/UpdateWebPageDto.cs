using WikiSumBackend.Contracts.Chapter;

namespace WikiSumBackend.Contracts.Webpage
{
    public class UpdateWebpageDto
    {
        //public string Url { get; set; } = string.Empty;
        public List<UpdateChapterDto> Chapters { get; set; } = new();
    }
}
