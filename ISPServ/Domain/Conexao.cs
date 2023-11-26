using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISPServ.Domain
{
    public class Conexao
    {
        [Key]
        [Column(TypeName = "INT")]
        public int Id { get; set; }

        [Required]
        public Tecnologia? Tecnologia { get; set; }

        [Required]
        public Plano? Plano { get; set; }

        [Required]
        public Endereco? Endereco { get; set; }

        [Required]
        public DateTime? DataCadastro { get; set; }

        [Required]
        public CTO? OLT { get; set; }

        [Required]
        public OLT? CTO { get; set; }

        [Required]
        public Contrato? Contrato { get; set; }

        [Required]
        public DateOnly DataInativação { get; set; }
    }
}
