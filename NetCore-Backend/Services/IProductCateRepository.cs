using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface IProductCateRepository
    {
        List<ProductCateModel> GetAll();
        ProductCateModel GetById(long id);
        ProductCateModel getByProductId(long id);
        ProductCateModel Add(ProductCateModel productCateModel);
        void Update(ProductCateModel productCateModel);
        void Delete(long id);
    }
}
