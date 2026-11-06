using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WikiSumBackend.Domain.Entiteiten
{
    public class ChapterTranslation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        public int ChapterId { get; set; }

        public Chapter Chapter { get; set; } = null!;

        public ICollection<Summary> Summaries { get; set; }
            = new List<Summary>();
    }
}
