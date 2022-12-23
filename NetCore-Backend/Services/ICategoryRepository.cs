using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface ICategoryRepository
    {
        List<CategoryModel> GetAll();
        CategoryModel GetById(long id);
        CategoryModel Add(CategoryModel categoryModel);
        void Update(CategoryModel categoryModel);
        void Delete(long id);
    }
}
