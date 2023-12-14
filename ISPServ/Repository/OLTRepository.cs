using ISPServ.Database;
using ISPServ.Domain;
using ISPServ.DTO;

namespace ISPServ.Repository
{
    public class OLTRepository(DatabaseContext db) : IOLTRepository
    {
        private readonly DatabaseContext _db = db;

        public void AddOLT(OLTDTO olt)
        {
            OLT _olt = new OLT()
            {
                Marca = olt.Marca,
                Modelo = olt.Modelo,
                Id = olt.Marca.GetHashCode() + olt.Modelo.GetHashCode()
            };

            _db.OLTs.Add(_olt);
            _db.SaveChanges();
        }

        public void EditarOLT(int oltId, OLTDTO olt)
        {
            var oltEdit = _db.OLTs.ToList().Find(o => o.Id == oltId);

            if(oltEdit != null)
            {
                oltEdit.Marca = olt.Marca;
                oltEdit.Modelo = olt.Modelo;

                _db.SaveChanges();  
            }
        }

        public List<OLT> GetOLT()
        {
            return [.. _db.OLTs];
        }

        public void InativarOLT(int oltId)
        {
            var oltInativar = _db.OLTs.ToList().Find(o => o.Id == oltId);

            if(oltInativar != null)
            {
                oltInativar.DataInativacao = DateOnly.FromDateTime(DateTime.Now);
                _db.SaveChanges();
            }
        }
    }
}
