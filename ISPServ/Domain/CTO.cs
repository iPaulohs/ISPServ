using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISPServ.Domain
{
    public class CTO
    {
        [Key]
        [Column(TypeName = "INT")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string? Codigo { get; set; }
    }
}
