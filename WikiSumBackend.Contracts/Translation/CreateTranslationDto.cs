using WikiSumBackend.Contracts.Summary;

namespace WikiSumBackend.Contracts.Translation
{
    public class CreateTranslationDto
    {
        public string Title { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        public List<CreateSummaryDto> Summaries { get; set; } = new();
    }
}
