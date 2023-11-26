using System.ComponentModel.DataAnnotations;

namespace ISPServ.Domain.User
{
    public class Superadmin : Usuario
    {
        [Required]
        public string? SenhaSuperadim { get; set; }
    }
}
