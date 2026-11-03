using WikiSumBackend.Contracts.Summary;

namespace WikiSumBackend.Contracts.Chapter
{

    public class ChapterDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int WebpageId { get; set; }

        public List<SummaryDto> Summaries { get; set; } = new();
    }
}
