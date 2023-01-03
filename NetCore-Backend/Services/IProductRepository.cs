using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface IProductRepository
    {
        List<ProductModel> GetAll(int start,int end,String ? sortBy);
        List<ProductModel> GetAllProductByCate();
        ProductModel GetById(long id);
        ProductModel Add(ProductModel productModel, IFormFile fileData, FileType fileType);
        void Update(ProductModel productModel);
        void Delete(long id);

        List<ProductModel> GetCateById(long id);
    }
}
