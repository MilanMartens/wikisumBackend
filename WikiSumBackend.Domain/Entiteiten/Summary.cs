using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WikiSumBackend.Domain.Entiteiten
{
    public class Summary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string SummaryText { get; set; } = string.Empty;

        //public string Language { get; set; } = string.Empty;

        //// Foreign key
        //public int ChapterId { get; set; }

        //// Navigation property
        //public Chapter Chapter { get; set; } = null!;

        public int ChapterTranslationId { get; set; }

        public ChapterTranslation ChapterTranslation { get; set; } = null!;
    }
}
