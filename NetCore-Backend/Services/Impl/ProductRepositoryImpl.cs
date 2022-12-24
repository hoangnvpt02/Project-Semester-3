using NetCore_Backend.Models;
using NetCore_Backend.Data;
namespace NetCore_Backend.Services.Impl
{
    public class ProductRepositoryImpl : IProductRepository
    {
        private readonly MyDbContext _context;
        public ProductRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }

        public ProductModel Add(ProductModel productModel)
        {
            var product = new Product();
            product.Address = productModel.Address;
            product.Author = productModel.Author;
            product.Name = productModel.Name;
            product.Description = productModel.Description;
            product.UserId = productModel.UserId;
            product.CountryId = productModel.CountryId;
            product.ManufactureYear = productModel.ManufactureYear;
            product.Quanlity = productModel.Quanlity;
            product.Updated = productModel.Updated;
            product.Created = productModel.Created;
            product.IsActive = productModel.IsActive;
            product.Price = productModel.Price;
            _context.Products.Add(product);
            _context.SaveChanges();
            return new ProductModel()
            {
                Address = product.Address,
                Author = product.Author,
                Name = product.Name,
                Description = product.Description,
                UserId = product.UserId,
                CountryId = product.CountryId,
                ManufactureYear = product.ManufactureYear,
                Quanlity = product.Quanlity,
                Updated = product.Updated,
                Created = product.Created,
                IsActive = product.IsActive,
                Price = product.Price,
            };

        }

        public void Delete(long id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<ProductModel> GetAll()
        {
            var products = _context.Products.Select(p => new ProductModel()
            {
                Id = p.Id,
                CountryId = p.CountryId,
                UserId = p.UserId,
                Address = p.Address,
                Author = p.Author,
                Name = p.Name,
                Price = p.Price,
                ManufactureYear = p.ManufactureYear,
                Quanlity = p.Quanlity,
                Description = p.Description,
                IsActive = p.IsActive,
                Created = p.Created,
                Updated = p.Updated,
            });
            return products.ToList();
        }

        public ProductModel GetById(long id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if( product != null)
            {
                return new ProductModel()
                {
                    Id = product.Id,
                    CountryId = product.CountryId,
                    UserId = product.UserId,
                    Address = product.Address,
                    Author = product.Author,
                    Name = product.Name,
                    Price = product.Price,
                    ManufactureYear = product.ManufactureYear,
                    Quanlity = product.Quanlity,
                    Description = product.Description,
                    IsActive = product.IsActive,
                    Created = product.Created,
                    Updated = product.Updated,
                };
            }
            return null;
        }

        public void Update(ProductModel productModel)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productModel.Id);
            if(product != null)
            {
                product.CountryId = productModel.CountryId;
                product.UserId = productModel.UserId;
                product.Address = productModel.Address;
                product.Author = productModel.Author;
                product.Name = productModel.Name;
                product.Price = productModel.Price;
                product.ManufactureYear = productModel.ManufactureYear;
                product.Quanlity = productModel.Quanlity;
                product.Description = productModel.Description;
                product.IsActive = productModel.IsActive;
                product.Updated = productModel.Updated;
                _context.Update(product);
                _context.SaveChanges();
            }
        }
    }
}
