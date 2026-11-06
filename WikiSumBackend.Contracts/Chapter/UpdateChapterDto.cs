using WikiSumBackend.Contracts.Translation;

namespace WikiSumBackend.Contracts.Chapter
{
    public class UpdateChapterDto
    {
        //public int Id { get; set; }
        public string OriginalTitle { get; set; } = string.Empty;
        //public string Title { get; set; } = string.Empty;
        //public List<UpdateSummaryDto> Summaries { get; set; } = new();
        public List<UpdateChapterTranslationDto> Translations { get; set; }
        = new();
    }
}
