using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISPServ.Domain
{
    public class Tecnologia
    {
        [Key]
        [Required]
        [Column(TypeName = "INT")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(15)")]
        public string? Tipo { get; set; }
    }
}
