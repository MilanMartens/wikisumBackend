using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WikiSumBackend.Domain.Entiteiten
{
    public class Webpage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Url { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
    }
}
