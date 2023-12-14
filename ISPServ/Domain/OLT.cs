using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISPServ.Domain
{
    public class OLT
    {
        [Key]
        [Column(TypeName = "INT")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string? Marca { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(30)")]
        public string? Modelo { get; set; }

        public DateOnly DataInativacao { get; set; }
    }
}
