using WikiSumBackend.Contracts.Translation;

namespace WikiSumBackend.Contracts.Chapter
{

    public class ChapterDto
    {
        public int WebpageId { get; set; }
        public List<TranslationDto> Translations { get; set; } = new();

    }
}
