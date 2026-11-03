namespace WikiSumBackend.Domain.Entiteiten
{
    public class Summary
    {
        public int Id { get; set; }

        public string SummaryText { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        // Foreign key
        public int ChapterId { get; set; }

        // Navigation property
        public Chapter Chapter { get; set; } = null!;
    }
}
