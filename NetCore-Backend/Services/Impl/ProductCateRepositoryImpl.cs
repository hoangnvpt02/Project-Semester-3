using NetCore_Backend.Models;
using NetCore_Backend.Data;



namespace NetCore_Backend.Services.Impl
{
    public class ProductCateRepositoryImpl : IProductCateRepository
    {
        private readonly MyDbContext _context;
        public ProductCateRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }
        public ProductCateModel Add(ProductCateModel productCateModel)
        {
            var productCate = new ProductCate();
            productCate.CategoryId = productCateModel.CategoryId;
            productCate.IsActive = productCateModel.IsActive;
            productCate.Created = productCateModel.Created;
            productCate.Updated = productCateModel.Updated;
            _context.Add(productCate);
            _context.SaveChanges();
            return new ProductCateModel()
            {
                Id = productCate.Id,
                CategoryId = productCate.CategoryId,
                IsActive = productCate.IsActive,
                Created = productCate.Created,
                Updated = productCate.Updated,
                ProductId = productCate.ProductId,
            };
        }

        public void Delete(long id)
        {
            var products = _context.ProductCates.FirstOrDefault(p => p.Id == id);
            if(products != null)
            {
                _context.ProductCates.Remove(products);
                _context.SaveChanges();
            }
        }
        public List<ProductCateModel> GetAll()
        {
            var productCaties = _context.ProductCates.Select(p => new ProductCateModel()
            {
                Id = p.Id,
                ProductId = p.ProductId,
                CategoryId = p.CategoryId,
                IsActive = p.IsActive,
                Updated = p.Updated,
                Created = p.Created,
            });
            return productCaties.ToList();
        }
        public ProductCateModel GetById(long id)
        {
            var productCate = _context.ProductCates.FirstOrDefault(p =>p.Id == id);
            if(productCate != null)
            {
                return new ProductCateModel()
                {
                    Id = productCate.Id,
                    ProductId = productCate.ProductId,
                    CategoryId = productCate.CategoryId,
                    IsActive = productCate.IsActive,
                    Updated = productCate.Updated,
                    Created = productCate.Created,
                };
            }
            return null;
        }
        public void Update(ProductCateModel productCateModel)
        {
            var productCate = _context.ProductCates.FirstOrDefault(p => p.Id == productCateModel.Id);
            if( productCate != null)
            {
                productCate.ProductId = productCateModel.ProductId;
                productCate.CategoryId = productCateModel.CategoryId;
                productCate.Updated = productCateModel.Updated;
                productCate.IsActive = productCateModel.IsActive;
                _context.Update(productCate);
                _context.SaveChanges();
            }
        }
    }
}
