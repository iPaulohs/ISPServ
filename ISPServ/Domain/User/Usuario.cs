using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISPServ.Domain.User
{
    public class Usuario : IdentityUser
    {
        [Key]
        [Required]
        [Column(TypeName = "VARCHAR(80)")]
        public override string? Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(80)")]
        public string? Nome { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(14)")]
        public string?  CPF { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(80)")]
        public override string?  Email { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string?  Password { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(25)")]
        public string?  Setor { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(25)")]
        public string?  Cargo { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool IsSuperadmin { get; set; } = false;

        [Column(TypeName = "DATE")]
        public DateOnly? DataInativacao { get; set; }

    }
}
