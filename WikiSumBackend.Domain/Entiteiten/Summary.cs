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
        public int ChapterTranslationId { get; set; }

        public ChapterTranslation ChapterTranslation { get; set; } = null!;
    }
}
