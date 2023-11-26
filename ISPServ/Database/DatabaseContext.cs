using ISPServ.Domain;
using ISPServ.Domain.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ISPServ.Database
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : IdentityDbContext<Usuario, IdentityRole, string>(options)
    {
        public DbSet<Superadmin> Superadmins { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conexao> Conexoes { get; set;}
        public DbSet<CTO> CTOs { get; set; }
        public DbSet<OLT> OLTs { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Tecnologia> Tecnologias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
    }
}
