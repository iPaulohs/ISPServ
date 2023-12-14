using ISPServ.Domain.User;
using ISPServ.DTO;
using ISPServ.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISPServ.Controllers
{
    [Authorize]
    [Route("/usuarios")]
    [ApiController]
    public class UsuarioController(IUsuarioRepository usuarioRepository) : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        [HttpGet("getadmins")]
        public List<AdminDTO> GetAdmins()
        {
            return _usuarioRepository.GetAdmins();
        }

        [HttpGet("getsuperadmins")]
        public List<SuperadminDTO> GetSuperAdmins()
        {
            return _usuarioRepository.GetSuperadmins();
        }

        [HttpDelete("inativaradmin/{cpf}")]
        public async Task<ActionResult> InativarAdmin([FromBody] string cpf)
        {
            if (!_usuarioRepository.InativarAdmin(cpf))
            {
                return BadRequest("O usuário não foi inativado. Favor repetir o processo.");
            }
            return Ok("Usuário inativado com sucesso.");
        }

        [HttpDelete("inativarsuperadmin/{cpf}")]
        public async Task<ActionResult> InativarSuperadmin([FromBody] string cpf)
        {
            if (!_usuarioRepository.InativarSuperadmin(cpf))
            {
                return BadRequest("O usuário não foi inativado. Favor repetir o processo.");
            }
            return Ok("Usuário inativado com sucesso.");
        }

        [HttpPost("cadastraradmin")]
        public async Task<ActionResult> AdicionarAdmin([FromBody] AdminDTO usuario)
        {
            Admin _admin = new()
            {
                Nome = usuario.Nome,
                CPF = usuario.CPF,
                Cargo = usuario.Cargo,
                Email = usuario.Email,
                DataNascimento = usuario.DataNascimento,
                Setor = usuario.Setor,
                Password = usuario.Password
            };

            _usuarioRepository.AddAdmin(_admin);
            return Ok("Usuário registrado com sucesso.");
        }
        [HttpPost("cadastrarsuperadmin")]
        public async Task<ActionResult> AdicionarSuperadmin([FromBody] SuperadminDTO usuario)
        {
            Superadmin _superadmin = new()
            {
                Nome = usuario.Nome,
                CPF = usuario.CPF,
                Cargo = usuario.Cargo,
                Email = usuario.Email,
                DataNascimento = usuario.DataNascimento,
                Setor = usuario.Setor,
                Password = usuario.Password,
                SenhaSuperadim = usuario.SenhaSuperadmin
            };

            _usuarioRepository.AddSuperadmin(_superadmin);
            return Ok("Usuário registrado com sucesso.");
        }

        [HttpPatch("editaradmin/{cpf}")]
        public void EditarAdmin(string cpf, AdminDTO adminDTO)
        {
            _usuarioRepository.EditarAdmin(cpf, adminDTO);
        }

        [HttpPatch("editarsuperadmin/{cpf}")]
        public void EditarSuperAdmin(string cpf, SuperadminDTO superadminDTO)
        {
           _usuarioRepository.EditarSuperadmin(cpf, superadminDTO);
        }
    }
}
