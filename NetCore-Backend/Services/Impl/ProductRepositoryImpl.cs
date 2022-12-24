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

        public ProductModel Add(ProductModel productModel, IFormFile fileData, FileType fileType)
        {
            var fileDetails = new FileDetails()
            {
                ID = 0,
                FileName = fileData.FileName,
                FileType = fileType,
            };

            if (fileData != null)
            {
               
                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    fileDetails.FileData = stream.ToArray();
                }

                var result = _context.FileDetails.Add(fileDetails);
                _context.SaveChanges();
            }
          
          
            var product = new Product();
            product.Address = productModel.Address;
            product.FileDetailsId = fileDetails.ID;
            product.Author = productModel.Author;
            product.Discription = productModel.Discription;
            product.UserId = productModel.UserId;
            product.CountryId = productModel.CountryId;
            product.ManufactureYear = productModel.ManufactureYear;
            product.Quanlity = productModel.Quanlity;
            product.Updated = DateTime.Now;
            product.Created =DateTime.Now;
            product.IsActive = productModel.IsActive;
            product.Price = productModel.Price;
            _context.Products.Add(product);
            _context.SaveChanges();
            return new ProductModel()
            {
                Address = product.Address,
                Author = product.Author,
                Discription = product.Discription,
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
                Price = p.Price,
                ManufactureYear = p.ManufactureYear,
                Quanlity = p.Quanlity,
                Discription = p.Discription,
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
                    Price = product.Price,
                    ManufactureYear = product.ManufactureYear,
                    Quanlity = product.Quanlity,
                    Discription = product.Discription,
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
                product.Price = productModel.Price;
                product.ManufactureYear = productModel.ManufactureYear;
                product.Quanlity = productModel.Quanlity;
                product.Discription = productModel.Discription;
                product.IsActive = productModel.IsActive;
                product.Updated = productModel.Updated;
                _context.Update(product);
                _context.SaveChanges();
            }
        }
    }
}
