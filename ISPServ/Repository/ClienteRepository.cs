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

        public void EditarCliente(string cpf, ClienteDTO cliente)
        {
            var clienteEdit = _db.Clientes.ToList().Find(c => c.CPF == cpf);

            if (clienteEdit != null)
            {
                clienteEdit.Nome = cliente.Nome;
                clienteEdit.CPF = cliente.CPF;
                clienteEdit.EnderecoResidencia.Pais = "Brasil";
                clienteEdit.EnderecoResidencia.Estado = cliente.EnderecoResidencia.Estado;
                clienteEdit.EnderecoResidencia.Cidade = cliente.EnderecoResidencia.Cidade;
                clienteEdit.EnderecoResidencia.Bairro = cliente.EnderecoResidencia.Bairro;
                clienteEdit.EnderecoResidencia.Rua = cliente.EnderecoResidencia.Rua;
                clienteEdit.EnderecoResidencia.Numero = cliente.EnderecoResidencia.Numero;
                clienteEdit.EnderecoResidencia.Complemento = cliente.EnderecoResidencia.Complemento;
                clienteEdit.DataCadastro = DateOnly.FromDateTime(DateTime.Now);
                clienteEdit.DataNascimento = cliente.DataNascimento;
                clienteEdit.RG = cliente.RG;
                clienteEdit.Sexo = cliente.Sexo;
                _db.SaveChanges();
            };

        }

        public List<Cliente> GetClientes()
        {
            return [.. _db.Clientes];
        }

        public bool InativarCliente([FromBody] string clienteParam)
        {

            var listClientes = GetClientes();
            var _cliente = listClientes.Find(c => c.Id == clienteParam);

            if (_cliente != null)
            {
                 _cliente.DataInativacao = DateOnly.FromDateTime(DateTime.Now);
                _db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
