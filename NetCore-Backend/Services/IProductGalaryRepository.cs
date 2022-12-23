using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface IProductGalaryRepository
    {
        List<ProductGalaryModel> GetAll();
        ProductGalaryModel GetById(long id);
        ProductGalaryModel Add(ProductGalaryModel productGalaryModel);
        void Update(ProductGalaryModel productGalaryModel);
        void Delete(long id);
    }
}
