using ISPServ.Domain;
using ISPServ.DTO;
using ISPServ.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ISPServ.Controllers
{
    [Controller]
    [Route("olt")]
    public class OLTController(IOLTRepository repository) : Controller
    {
        private readonly IOLTRepository _repository = repository;

        [HttpPost("add")]
        public ActionResult AddOlt(OLTDTO olt)
        {
            _repository.AddOLT(olt);
            return Ok();
        }

        [HttpGet]
        public List<OLT> GetOLTs()
        {
            return _repository.GetOLT();
        }

        [HttpPatch("editar/{id}")]
        public void EditOLT(int id, OLTDTO olt)
        {
            _repository.EditarOLT(id, olt);
        }

        [HttpDelete("inativar/{id}")]
        public ActionResult DeleteOLT(int id)
        {
            _repository.InativarOLT(id);
            return Ok();
        }

    }
}
