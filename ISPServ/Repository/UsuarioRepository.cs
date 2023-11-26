using AutoMapper;
using ISPServ.Database;
using ISPServ.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ISPServ.Repository
{
    public class UsuarioRepository(DatabaseContext db, IMapper mapper) : IUsuarioRepository
    {
        private readonly DatabaseContext _db = db;
        private readonly IMapper _mapper = mapper;

        public List<UsuarioDTO> GetUsuarios()
        {
            var usuarios = _mapper.Map<List<UsuarioDTO>>(_db.Users.ToList());
            return usuarios;
        }

        public bool InativarUsuario([FromBody] string usuarioParamCPF)
        {

            var listUsuarios = _db.Users.ToList();
            var usuario = listUsuarios.Find(c => c.CPF == usuarioParamCPF);

            if (usuario != null)
            {
                usuario.DataInativacao = DateOnly.FromDateTime(DateTime.Now);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
