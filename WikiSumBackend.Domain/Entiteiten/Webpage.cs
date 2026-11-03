namespace WikiSumBackend.Domain.Entiteiten
{
    public class Webpage
    {
        public int Id { get; set; }

        public string Url { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
    }
}
