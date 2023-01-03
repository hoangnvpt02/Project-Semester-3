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
            product.Name = productModel.Name;
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
                Name = product.Name,
                Discription = product.Discription,
                UserId = (long)product.UserId,
                CountryId = (long)product.CountryId,
                ManufactureYear = product.ManufactureYear,
                Quanlity = product.Quanlity,
                Updated = product.Updated,
                Created = product.Created,
                IsActive = product.IsActive,
                Price = product.Price,
                FileDetailsId = product.FileDetailsId,
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

        public List<ProductModel> GetAll(int start,int end,String sortBy)
        {

            var products = _context.Products.Select(p => new ProductModel()
            {
                Id = p.Id,
                CountryId = (long)p.CountryId,
                UserId = (long)p.UserId,
                Address = p.Address,
                Author = p.Author,
                Name = p.Name,
                Price = p.Price,
                ManufactureYear = p.ManufactureYear,
                Quanlity = p.Quanlity,
                Discription = p.Discription,
                FileDetailsId = p.FileDetailsId,
                IsActive = p.IsActive,
                Created = p.Created,
                Updated = p.Updated,
            });
            
            products.OrderByDescending(p => p.Created).ToList();
            if(sortBy != null)
            {
                switch (sortBy)
                {
                    case "price":
                        products = products.OrderByDescending(p => p.Price);
                        break;
                    default:
                        break;
                }
            }
            if(start != 0 || end != 0)
            {
                products = products.Skip(start).Take(end);
            }
           
            return products.ToList();
        }

       

        public ProductModel GetById(long id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if( product != null)
            {
                Product product1 = product;
                return new ProductModel()
                {
                    Id = product.Id,
                    CountryId = (long)product.CountryId,
                    UserId = (long)product.UserId,
                    Address = product.Address,
                    Author = product.Author,
                    Name = product.Name,
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
                product.Name = productModel.Name;
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
        public List<ProductModel> GetCateById(long id)
        {
            List<ProductCate> productCates = _context.ProductCates.Where(c => c.CategoryId == id).ToList();
            if(productCates.Count > 0)
            {
                List<ProductModel> products = new List<ProductModel>();
                foreach (ProductCate productCate in productCates)
                {
                    Product product = _context.Products.FirstOrDefault(c => c.Id == productCate.Id);
                    ProductModel model = new ProductModel() { 
                        Id = product.Id,
                        UserId= (long)product.UserId,
                        CountryId = (long)product.CountryId,
                        Price = product.Price,
                        Author = product.Author,
                        Name = product.Name,
                        ManufactureYear=product.ManufactureYear,
                        Discription = product.Discription,
                        FileDetailsId = product.FileDetailsId,
                        Quanlity = product.Quanlity,
                        IsActive = product.IsActive,
                        Address = product.Address,
                        Created = product.Created,
                        Updated = product.Updated,
                    };
                    products.Add(model);
                }
                return products;
            }
            return null;
        }
    }
}
