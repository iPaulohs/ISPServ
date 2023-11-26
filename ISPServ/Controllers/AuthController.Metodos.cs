using ISPServ.Domain.User;
using ISPServ.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ISPServ.Controllers
{
    public partial class AuthController
    {
        private UsuarioTokenDTO GenerateToken(Usuario user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                new Claim("[_ISPServ_]", "[_TodosOsDireitosReservados_]"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expirationToken = DateTime.UtcNow.AddHours(double.Parse(_configuration["TokenConfiguration:ExpireHour"]));

            JwtSecurityToken token = new(issuer: _configuration["TokenConfiguration:Issuer"], audience: _configuration["TokenConfiguration:Audience"], claims: claims, expires: expirationToken, signingCredentials: credentials);

            return new UsuarioTokenDTO()
            {
                Autenticado = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracao = expirationToken,
                Mensagem = "Generate token sucessfull.",
                UsuarioId = user.Id,
                UserName = user.UserName
            };
        }

        private static string GeraPassword(string nome)
        {
            int indexEspaco = nome.IndexOf(" ") + 1;
            string _nome = nome[..indexEspaco];
            return RemoverAcentos(_nome);
        }

        public static string RemoverAcentos(string texto)
        {
            string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";
            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }
            return texto;
        }
    }
}
