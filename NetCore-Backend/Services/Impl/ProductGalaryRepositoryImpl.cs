using NetCore_Backend.Models;
using NetCore_Backend.Data;

namespace NetCore_Backend.Services.Impl
{
    public class ProductGalaryRepositoryImpl : IProductGalaryRepository
    {
        private readonly MyDbContext _context;
        public ProductGalaryRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }

        public ProductGalaryModel Add(ProductGalaryModel productGalaryModel)
        {
            var productGalary = new ProductGalary();
            productGalary.ProductId = productGalaryModel.ProductId;
            productGalary.GalaryId = productGalaryModel.GalaryId;
            productGalary.IsActive = productGalaryModel.IsActive;
            productGalary.Created = productGalaryModel.Created;
            productGalary.Updated = productGalaryModel.Updated;
            _context.Add(productGalary);
            _context.SaveChanges();
            return new ProductGalaryModel()
            {
                Id = productGalary.Id,
                ProductId = productGalary.ProductId,
                GalaryId = productGalary.GalaryId,
                IsActive = productGalary.IsActive,
                Updated = productGalary.Updated,
                Created = productGalary.Created,
            };
        }

        public void Delete(long id)
        {
            var productGalary = _context.ProductGalaries.FirstOrDefault(x => x.Id == id);
            if(productGalary != null)
            {
                _context.ProductGalaries.Remove(productGalary);
                _context.SaveChanges();
            }
        }

        public List<ProductGalaryModel> GetAll()
        {
            var productGalaries = _context.ProductGalaries.Select(p => new ProductGalaryModel()
            {
                Id = p.Id,
                ProductId = p.ProductId,
                GalaryId = p.GalaryId,
                IsActive = p.IsActive,
                Updated = p.Updated,
                Created = p.Created,
            });
            return productGalaries.ToList();
        }

        public ProductGalaryModel GetById(long id)
        {
            var productGalary = _context.ProductGalaries.FirstOrDefault(p => p.Id == id);
            if(productGalary != null)
            {
                return new ProductGalaryModel()
                {
                    Id = productGalary.Id,
                    ProductId = productGalary.ProductId,
                    GalaryId = productGalary.GalaryId,
                    IsActive = productGalary.IsActive,
                    Updated = productGalary.Updated,
                    Created = productGalary.Created,
                };
            }
            return null;
        }

        public void Update(ProductGalaryModel productGalaryModel)
        {
            var productGalary = _context.ProductGalaries.FirstOrDefault(p => p.Id == productGalaryModel.Id);
            if( productGalary != null)
            {
                productGalary.ProductId = productGalaryModel.ProductId;
                productGalary.GalaryId = productGalaryModel.GalaryId;
                productGalary.IsActive = productGalaryModel.IsActive;
                productGalary.Updated = productGalaryModel.Updated;
                _context.Update(productGalary);
                _context.SaveChanges();
            }
           
        }
    }
}
