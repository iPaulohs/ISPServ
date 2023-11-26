using ISPServ.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISPServ.Domain
{
    public class Cliente
    {
        [Key]
        [Column(TypeName = "VARCHAR(80)")]
        public string? Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(80)")]
        public string? Nome { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF deve estar no formato 999.999.999-99")]
        public string? CPF { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string? RG { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime DataNascimento { get; set; }

        [Required]
        public Endereco? EnderecoResidencia { get; set; }

        [Required]
        public Sexo Sexo { get; set; }

        public ICollection<Conexao>? Conexoes { get; set; }

        [Column(TypeName = "DATE")]
        public DateOnly? DataCadastro { get; set; }

        [Column(TypeName = "DATE")]
        public DateOnly? DataInativacao { get; set; }
    }
}
