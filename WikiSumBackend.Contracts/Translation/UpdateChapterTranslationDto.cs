using WikiSumBackend.Contracts.Summary;

namespace WikiSumBackend.Contracts.Translation
{
    public class UpdateChapterTranslationDto
    {
        public string Title { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        public List<UpdateSummaryDto> Summaries { get; set; } = new();
    }
}
