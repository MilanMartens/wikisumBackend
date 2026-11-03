namespace WikiSumBackend.Contracts.Chapter
{
    public class UpdateChapterDto
    {
        // Ik laat WebpageId weg uit UpdateChapterDto, omdat een hoofdstuk bij dezelfde webpagina blijft horen.
        public string Title { get; set; } = string.Empty;
    }
}
