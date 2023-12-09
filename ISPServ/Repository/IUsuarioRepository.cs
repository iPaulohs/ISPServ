using ISPServ.Domain.User;
using ISPServ.DTO;

namespace ISPServ.Repository
{
    public interface IUsuarioRepository
    {
        public bool InativarUsuario(string clienteParam);
        public void AddAdmin(Admin usuario);
        public void AddSuperadmin(Superadmin usuario);
        public List<SuperadminDTO> GetSuperadmins();
        public List<AdminDTO> GetAdmins();
        public void EditarSuperadmin(string superadminCpf, SuperadminDTO superadminDTO);
        public void EditarAdmin(string superadminCpf, AdminDTO superadminDTO);
    }
}
