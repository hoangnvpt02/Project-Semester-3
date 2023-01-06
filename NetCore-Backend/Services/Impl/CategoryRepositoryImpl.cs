using NetCore_Backend.Models;
using NetCore_Backend.Data;

namespace NetCore_Backend.Services.Impl
{
    public class CategoryRepositoryImpl : ICategoryRepository
    {
        private readonly MyDbContext _context;
        public CategoryRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }

        public CategoryModel Add(CategoryModel categoryModel)
        {
            var category = new Category();
            category.Name = categoryModel.Name;
            category.Description = categoryModel.Description;
            category.IsActive = categoryModel.IsActive;
            category.Created = categoryModel.Created;
            category.Updated = categoryModel.Updated;
            _context.Categories.Add(category);
            _context.SaveChanges();
            return new CategoryModel()
            {
                Name = category.Name,
                Description = category.Description,
                IsActive = categoryModel.IsActive,
                Created = categoryModel.Created,
                Updated = categoryModel.Updated,
            };
        }

        public void Delete(long id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if(category != null)
            {
                category.IsActive = 1;
                _context.SaveChanges();
            }
        }

        public List<CategoryModel> GetAll()
        {
            var categories = _context.Categories.Where(c => c.IsActive == 0).Select(c => new CategoryModel()
            {
                Id = c.Id,
                Name = c.Name,
                IsActive = c.IsActive,
                Updated = c.Updated,
                Created = c.Created,
                Description = c.Description,
            });
            return categories.ToList();
        }

        public CategoryModel GetById(long id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if(category != null)
            {
                return new CategoryModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    IsActive = category.IsActive,
                    Updated = category.Updated,
                    Created = category.Created,
                    Description = category.Description,
                };
            }
            return null;
        }

        public void Update(CategoryModel categoryModel)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == categoryModel.Id);
            if(category != null)
            {
                category.IsActive = categoryModel.IsActive;
                category.Updated = categoryModel.Updated;
                category.Name = categoryModel.Name;
                category.Description = categoryModel.Description;
                _context.Update(category);
                _context.SaveChanges();
            }
        }
    }
}
