using ISPServ.Domain.User;
using ISPServ.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ISPServ.Controllers
{
    [Route("/auth")]
    [ApiController]
    public partial class AuthController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IConfiguration configuration) : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager = userManager;
        private readonly SignInManager<Usuario> _signInManager = signInManager;
        private readonly IConfiguration _configuration = configuration;

        [HttpGet]
        public ActionResult<string> APIOperando()
        {
            var response = $"API operando normalmente em: {DateTime.Now.ToLocalTime()}";
            return new JsonResult(response)
            {
                StatusCode = 200
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegistroUsuario([FromBody] UsuarioDTO modelo)
        {
            var usuarioIdDTO = $"[{modelo.CPF.GetHashCode().ToString().Replace("-", "")}]";
            var usuarioUsernamedDTO = $"{modelo.CPF.Replace(".", "").Replace("-", "")}@{GeraPassword(modelo.Nome).TrimEnd().Normalize()}";

            Usuario usuario = new()
            {
                Id = usuarioIdDTO,
                Nome = modelo.Nome,
                UserName = usuarioUsernamedDTO,
                EmailConfirmed = true,
                DataNascimento = modelo.DataNascimento,
                Cargo = modelo.Cargo,
                Setor = modelo.Setor,
                CPF = modelo.CPF,
                Email = modelo.Email,
                IsSuperadmin = modelo.IsSuperadmin,
                Password = modelo.Password,
            };

            var resultado = await _userManager.CreateAsync(usuario, modelo.Password);

            if (!resultado.Succeeded)
                return BadRequest(resultado.Errors);

            await _userManager.SetLockoutEnabledAsync(usuario, false);
            return Ok(GenerateToken(usuario));
        }
    }
}
