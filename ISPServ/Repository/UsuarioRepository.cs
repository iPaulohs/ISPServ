using AutoMapper;
using ISPServ.Database;
using ISPServ.Domain.User;
using ISPServ.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ISPServ.Repository
{
    public class UsuarioRepository(DatabaseContext db, IMapper mapper) : IUsuarioRepository
    {
        private readonly DatabaseContext _db = db;
        private readonly IMapper _mapper = mapper;

        public List<AdminDTO> GetAdmins()
        {
            var admins = _mapper.Map<List<AdminDTO>>(_db.Users.ToList());
            return admins;
        }

        public List<SuperadminDTO> GetSuperadmins()
        {
            var superadmins = _mapper.Map<List<SuperadminDTO>>(_db.Superadmins.ToList());
            return superadmins;
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

        public void AddAdmin(Admin usuario)
        {
            _db.Admins.Add(usuario);
            _db.SaveChanges();
        }

        public void AddSuperadmin(Superadmin usuario)
        {
            _db.Superadmins.Add(usuario);
            _db.SaveChanges();
        }

        public void EditarSuperadmin(string superadminCpf, SuperadminDTO superadminDTO)
        {
            var superadmin = _db.Superadmins.ToList().Find(s => s.CPF == superadminCpf);
            
            if(superadmin != null)
            {
                superadmin.CPF = superadminDTO.CPF;
                superadmin.Nome = superadminDTO.Nome;
                superadmin.Cargo = superadminDTO.Cargo;
                superadmin.SenhaSuperadim = superadminDTO.SenhaSuperadmin;
                superadmin.Cargo = superadminDTO.Cargo;
                superadmin.Email = superadminDTO.Email;
                superadmin.Password = superadminDTO.Password;
                superadmin.Setor = superadminDTO.Setor;
                _db.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("CPF não encontrado.");
            }
        }

        public void EditarAdmin(string superadminCpf, AdminDTO adminDTO)
        {
            var superadmin = _db.Admins.ToList().Find(s => s.CPF == superadminCpf);

            if (superadmin != null)
            {
                superadmin.CPF = adminDTO.CPF;
                superadmin.Nome = adminDTO.Nome;
                superadmin.Cargo = adminDTO.Cargo;
                superadmin.Cargo = adminDTO.Cargo;
                superadmin.Email = adminDTO.Email;
                superadmin.Password = adminDTO.Password;
                superadmin.Setor = adminDTO.Setor;
                _db.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("CPF não encontrado.");
            }
        }
    }
}
