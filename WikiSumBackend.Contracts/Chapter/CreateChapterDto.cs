using WikiSumBackend.Contracts.Summary;

namespace WikiSumBackend.Contracts.Chapter
{
    public class CreateChapterDto
    {
        public string Title { get; set; } = string.Empty;

        public int WebpageId { get; set; }
        public List<CreateSummaryDto> Summaries { get; set; } = new();
    }
}
