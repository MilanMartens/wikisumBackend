using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WikiSumBackend.Domain.Entiteiten
{
    public class Chapter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public string Title { get; set; } = string.Empty;

        // Foreign key
        public int WebpageId { get; set; }

        // Navigation properties
        public Webpage Webpage { get; set; } = null!;

        //public ICollection<Summary> Summaries { get; set; } = new List<Summary>();
        public ICollection<ChapterTranslation> Translations { get; set; }
     = new List<ChapterTranslation>();
    }
}
