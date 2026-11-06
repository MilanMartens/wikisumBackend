using WikiSumBackend.Contracts.Summary;

namespace WikiSumBackend.Contracts.Translation
{
    public class TranslationDto
    {
        public string Title { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        public List<SummaryDto> Summaries { get; set; } = new();
    }
}
