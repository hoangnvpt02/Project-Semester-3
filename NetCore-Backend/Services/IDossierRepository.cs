using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface IDossierRepository
    {
        List<DossierModel> GetAll();
        DossierModel GetById(long id);
        DossierModel Add(DossierModel dossierModel);
        void Update(DossierModel dossierModel);
        void Delete(long id);
    }
}
