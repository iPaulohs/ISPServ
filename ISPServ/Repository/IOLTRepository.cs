using ISPServ.Domain;
using ISPServ.DTO;

namespace ISPServ.Repository
{
    public interface IOLTRepository
    {
        public void AddOLT(OLTDTO olt);
        public void InativarOLT(int oltId);
        public void EditarOLT(int oltId, OLTDTO olt);
        public List<OLT> GetOLT();
    }
}
