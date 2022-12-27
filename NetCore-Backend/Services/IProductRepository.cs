using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface IProductRepository
    {
        List<ProductModel> GetAll();
        List<ProductModel> GetAllProductByCate();
        ProductModel GetById(long id);
        ProductModel Add(ProductModel productModel, IFormFile fileData, FileType fileType);
        void Update(ProductModel productModel);
        void Delete(long id);
    }
}
