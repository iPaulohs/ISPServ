using ISPServ.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ISPServ.Repository
{
    public class PlanoRepository : IPlanoRepository
    {
        public void CadastrarPlano([FromBody] Plano plano)
        {
            throw new NotImplementedException();
        }
    }
}
