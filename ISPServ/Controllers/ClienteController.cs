using AutoMapper;
using ISPServ.Domain;
using ISPServ.DTO;
using ISPServ.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ISPServ.Controllers
{
    [ApiController]
    [Route("/clientes")]
    public class ClienteController(IClienteRepository clienteRepository, IMapper mapper) : Controller
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;  

        [HttpPost("adicionar")]
        public async Task<ActionResult> AddCliente([FromBody] ClienteDTO cliente)
        {
            Cliente _cliente = new()
            {
                Id = $"[{cliente.CPF.GetHashCode().ToString().Replace("-", "")}]",
                CPF = cliente.CPF,
                Nome = cliente.Nome,
                EnderecoResidencia = new Endereco()
                {
                    Pais = cliente.EnderecoResidencia.Pais,
                    Estado = cliente.EnderecoResidencia.Estado,
                    Bairro = cliente.EnderecoResidencia.Bairro,
                    Cidade = cliente.EnderecoResidencia.Cidade,
                    Numero = cliente.EnderecoResidencia.Numero,
                    Rua = cliente.EnderecoResidencia.Rua,
                    Complemento = cliente.EnderecoResidencia.Complemento,
                    Id = $"[{cliente.CPF.GetHashCode().ToString().Replace("-", "")}@{Guid.NewGuid().GetHashCode().ToString().Replace("-", "")}]"
                },
                DataCadastro = DateOnly.FromDateTime(DateTime.Now),
                DataNascimento = cliente.DataNascimento,
                RG = cliente.RG,
                Sexo = cliente.Sexo,
                DataInativacao = null
            };

            var result = _clienteRepository.AddCliente(_cliente);

            if (!result.IsCompletedSuccessfully)
            {
                return BadRequest(result.Status);
            }

            return Ok($"Cliente {cliente.Nome} adicionado com sucesso!");
        }

        [HttpPatch("inativar")]
        public ActionResult InativarCliente([FromBody] string clienteParam)
        {
            if (!_clienteRepository.InativarCliente(clienteParam))
            {
                return BadRequest("Cliente não encontrado.");
            }
            return Ok("Cliente inativado com sucesso.");
        }
    }
}
