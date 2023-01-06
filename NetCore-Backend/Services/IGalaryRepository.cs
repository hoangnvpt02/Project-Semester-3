using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface IGalaryRepository
    {
        List<GalaryModel> GetAll();
        GalaryModel GetById(long id);
        GalaryModel Add(GalaryModel galary);
        void Update(GalaryModel galary);
        void Delete(long id);

        List<ProductModel> GetProductByGalaryId(long galaryId);
    }
}
