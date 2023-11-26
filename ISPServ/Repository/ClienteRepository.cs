using ISPServ.Database;
using ISPServ.Domain;
using ISPServ.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ISPServ.Repository
{
    public class ClienteRepository(DatabaseContext db) : IClienteRepository
    {
        private readonly DatabaseContext _db = db;

        public async Task AddCliente(Cliente cliente)
        {
            _db.Clientes.Add(cliente);
            _db.SaveChanges();
        }

        public List<Cliente> GetClientes()
        {
            return  [.. _db.Clientes];
        }

        public bool InativarCliente([FromBody] string clienteParam)
        {

            var listClientes = GetClientes();
            var _cliente = listClientes.Find(c => c.Id == clienteParam);

            if(_cliente != null)
            {
                _cliente.DataInativacao = DateOnly.FromDateTime(DateTime.Now);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
