using WikiSumBackend.Contracts.Translation;

namespace WikiSumBackend.Contracts.Chapter
{
    public class UpdateChapterDto
    {
        public string OriginalTitle { get; set; } = string.Empty;
        public List<UpdateChapterTranslationDto> Translations { get; set; }
        = new();
    }
}
