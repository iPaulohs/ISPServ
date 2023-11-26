using ISPServ.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISPServ.Domain
{
    public class Endereco
    {
        [Key]
        [Column(TypeName = "VARCHAR(50)")]
        public string? Id { get; set; }
        
        [Required]
        [Column(TypeName = "VARCHAR(30)")]
        public string? Pais { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(30)")]
        public Estado Estado { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(30)")]
        public string? Cidade { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(30)")]
        public string? Bairro { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(150)")]
        public string? Rua { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int Numero { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string? Complemento { get; set; }
    }
}
