using ISPServ.Domain.User;
using ISPServ.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ISPServ.Repository
{
    public interface IUsuarioRepository
    {
        public List<UsuarioDTO> GetUsuarios();
        public bool InativarUsuario(string clienteParam);
    }
}
