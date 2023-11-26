using ISPServ.DTO;
using ISPServ.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ISPServ.Controllers
{
    [Route("/usuarios")]
    [ApiController]
    public class UsuarioController(IUsuarioRepository usuarioRepository) : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        [HttpGet]
        public List<UsuarioDTO> Get()
        {
            return _usuarioRepository.GetUsuarios();
        }

        [HttpPatch("inativar")]
        public async Task<ActionResult> InativarUsuario([FromBody] string clienteParam)
        {
            if (!_usuarioRepository.InativarUsuario(clienteParam))
            {
                return BadRequest("O usuário não foi inativado. Verificar Logs.");
            }
            return Ok("Usuário inativado com sucesso.");
        }
    }
}
