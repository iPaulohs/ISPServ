using ISPServ.Domain;
using ISPServ.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ISPServ.Repository
{
    public interface IClienteRepository
    {
        public Task AddCliente(Cliente cliente);
        public List<Cliente> GetClientes();
        public bool InativarCliente([FromBody] string clienteParamID);
    }
}
