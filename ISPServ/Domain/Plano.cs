using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISPServ.Domain
{
    public class Plano
    {
        [Key]
        [Column(TypeName = "INT")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(150)")]
        public string? NomeComercial { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int VelocidadeDown { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int VelocidadeUp { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime DataAtivacao { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime DataInativacao { get; set; }

    }
}
