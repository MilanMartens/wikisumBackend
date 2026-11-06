using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WikiSumBackend.Domain.Entiteiten
{
    public class Chapter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Foreign key
        public int WebpageId { get; set; }

        // Navigation properties
        public Webpage Webpage { get; set; } = null!;
        public ICollection<ChapterTranslation> Translations { get; set; }
     = new List<ChapterTranslation>();
    }
}
