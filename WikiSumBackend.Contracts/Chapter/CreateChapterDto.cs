using WikiSumBackend.Contracts.Translation;

namespace WikiSumBackend.Contracts.Chapter
{
    public class CreateChapterDto
    {
        public int WebpageId { get; set; }
        public List<CreateTranslationDto> Translations { get; set; } = new();

    }
}
