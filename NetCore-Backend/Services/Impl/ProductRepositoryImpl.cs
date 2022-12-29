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

            product.Description = productModel.Description;
            product.AspNetUsersId = productModel.AspNetUsersId;

            product.CountryId = productModel.CountryId;
            product.ManufactureYear = productModel.ManufactureYear;
            product.Quanlity = productModel.Quanlity;
            product.Updated = DateTime.Now;
            product.Created =DateTime.Now;
            product.IsActive = productModel.IsActive;
            product.IsFeature = productModel.IsFeature;
            product.Price = productModel.Price;
            _context.Products.Add(product);
            _context.SaveChanges();
            return new ProductModel()
            {
                Address = product.Address,
                Author = product.Author,

                Description = product.Description,
                AspNetUsersId = product.AspNetUsersId,

                CountryId = product.CountryId,
                ManufactureYear = product.ManufactureYear,
                Quanlity = product.Quanlity,
                Updated = product.Updated,
                Created = product.Created,
                IsActive = product.IsActive,
                IsFeature = product.IsFeature,
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
                CountryId = p.CountryId,
                AspNetUsersId = p.AspNetUsersId,
                Address = p.Address,
                Author = p.Author,
                Name = p.Name,
                Price = p.Price,
                ManufactureYear = p.ManufactureYear,
                Quanlity = p.Quanlity,
                Description = p.Description,
                FileDetailsId = p.FileDetailsId,
                IsActive = p.IsActive,
                IsFeature = p.IsFeature,
                SalePercent = p.SalePercent,
                PriceSale = p.PriceSale,
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
                return new ProductModel()
                {
                    Id = product.Id,
                    CountryId = product.CountryId,
                    AspNetUsersId = product.AspNetUsersId,
                    Address = product.Address,
                    Author = product.Author,
                    Name = product.Name,
                    Price = product.Price,
                    ManufactureYear = product.ManufactureYear,
                    Quanlity = product.Quanlity,
                    Description = product.Description,
                    FileDetailsId = product.FileDetailsId,
                    IsActive = product.IsActive,
                    IsFeature = product.IsFeature,
                    SalePercent = product.SalePercent,
                    PriceSale = product.PriceSale,
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
                product.AspNetUsersId = productModel.AspNetUsersId;
                product.Address = productModel.Address;
                product.Author = productModel.Author;
                product.Name = productModel.Name;
                product.Price = productModel.Price;
                product.ManufactureYear = productModel.ManufactureYear;
                product.Quanlity = productModel.Quanlity;
                product.Description = productModel.Description;
                product.IsActive = productModel.IsActive;
                product.IsFeature = productModel.IsFeature;
                product.SalePercent = productModel.SalePercent;
                product.Updated = productModel.Updated;
                if (productModel.SalePercent > 0)
                {
                    product.PriceSale = product.Price - (product.Price * (decimal)productModel.SalePercent /100);
                }
                _context.Update(product);
                _context.SaveChanges();
            }
           
        }

        public List<ProductModel> GetAllProductByCate()
        {
            var categorizedProducts = _context.Products
                                    .Join(_context.ProductCates, p => p.Id, pc => pc.ProductId, (p, pc) => new { p, pc })
                                    .Join(_context.Categories, ppc => ppc.pc.CategoryId, c => c.Id, (ppc, c) => new { ppc, c })
                                    .Select(m => new ProductModel
                                    {
                                        Id = m.ppc.p.Id,
                                        Name = m.ppc.p.Name,
                                        CountryId = m.ppc.p.CountryId,
                                        AspNetUsersId = m.ppc.p.AspNetUsersId,
                                        Address = m.ppc.p.Address,
                                        Author = m.ppc.p.Author,
                                        Price = m.ppc.p.Price,
                                        ManufactureYear = m.ppc.p.ManufactureYear,
                                        Quanlity = m.ppc.p.Quanlity,
                                        IsActive = m.ppc.p.IsActive,
                                        IsFeature = m.ppc.p.IsFeature,
                                        SalePercent = m.ppc.p.SalePercent,
                                        PriceSale = m.ppc.p.PriceSale,
                                        Updated = m.ppc.p.Updated
        });
            return (List<ProductModel>)categorizedProducts;
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
                        AspNetUsersId =product.AspNetUsersId,
                        CountryId = product.CountryId,
                        Price = product.Price,
                        Author = product.Author,
                        Name = product.Name,
                        ManufactureYear=product.ManufactureYear,
                        Description = product.Description,
                        FileDetailsId = product.FileDetailsId,
                        Quanlity = product.Quanlity,
                        IsActive = product.IsActive,
                        IsFeature = product.IsFeature,
                        SalePercent = product.SalePercent,
                        PriceSale = product.PriceSale,
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

        public List<ProductModel> GetAllProductByFeature()
        {
           var products = _context.Products.Where(p => p.IsFeature == 0).Select(p => new ProductModel()
            {
                Id = p.Id,
               AspNetUsersId = p.AspNetUsersId,
                CountryId = p.CountryId,
                Price = p.Price,
                Author = p.Author,
                Name = p.Name,
                ManufactureYear = p.ManufactureYear,
                Description = p.Description,
                FileDetailsId = p.FileDetailsId,
                Quanlity = p.Quanlity,
                IsActive = p.IsActive,
                IsFeature = p.IsFeature,
                SalePercent = p.SalePercent,
                PriceSale = p.PriceSale,
                Address = p.Address,
                Created = p.Created,
                Updated = p.Updated,
            });

          
            return products.ToList();
        }

        public List<ProductModel> GetAllProductBySale()
        {
            var products = _context.Products.Where(p => p.SalePercent > 0).Select(p => new ProductModel()
            {
                Id = p.Id,
                AspNetUsersId = p.AspNetUsersId,
                CountryId = p.CountryId,
                Price = p.Price,
                Author = p.Author,
                Name = p.Name,
                ManufactureYear = p.ManufactureYear,
                Description = p.Description,
                FileDetailsId = p.FileDetailsId,
                Quanlity = p.Quanlity,
                IsActive = p.IsActive,
                IsFeature = p.IsFeature,
                SalePercent = p.SalePercent,
                PriceSale = p.PriceSale,
                Address = p.Address,
                Created = p.Created,
                Updated = p.Updated,
            });

            return products.ToList();
        }
    }
}
