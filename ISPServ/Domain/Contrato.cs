using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISPServ.Domain
{
    public class Contrato
    {
        [Required]
        [Column(TypeName = "VARCHAR(80)")]
        public string? Id { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateOnly DataAtivacao { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateOnly DataVencimento { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool IsAtivo { get; set; }
    }
}
