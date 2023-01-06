    using NetCore_Backend.Models;
using NetCore_Backend.Data;
namespace NetCore_Backend.Services.Impl
{
    public class AuctionProductRepositoryImpl : IAuctionProductRepository
    {
        private readonly MyDbContext _context;
        public AuctionProductRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }

        public AuctionProductModel Add(AuctionProductModel auctionProductModel, IFormFile fileData, FileType fileType)
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
          
          
            var product = new AuctionProduct();
            product.FileDetailsId = fileDetails.ID;
            product.Author = auctionProductModel.Author;
            product.Name = auctionProductModel.Name;

            product.Description = auctionProductModel.Description;
            product.AspNetUsersId = auctionProductModel.AspNetUsersId;

            product.Quanlity = auctionProductModel.Quanlity;
            product.Updated = DateTime.Now;
            product.Created =DateTime.Now;
            product.IsActive = auctionProductModel.IsActive;
            product.PriceStart = auctionProductModel.PriceStart;
            _context.AuctionProducts.Add(product);
            _context.SaveChanges();
            return new AuctionProductModel()
            {
                Author = product.Author,

                Description = product.Description,
                AspNetUsersId = product.AspNetUsersId,

                Quanlity = product.Quanlity,
                Updated = product.Updated,
                Created = product.Created,
                IsActive = product.IsActive,
                PriceStart = product.PriceStart,
                FileDetailsId = product.FileDetailsId,
            };

        }

        public void Delete(long id)
        {
            var product = _context.AuctionProducts.FirstOrDefault(p => p.Id == id);
            if(product != null)
            {
                _context.AuctionProducts.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<AuctionProductModel> GetAll(int start,int end,String sortBy)
        {

            var products = _context.AuctionProducts.Select(p => new AuctionProductModel()
            {
                Id = p.Id,
                AspNetUsersId = p.AspNetUsersId,
                Author = p.Author,
                Name = p.Name,
                PriceStart = p.PriceStart,
                Quanlity = p.Quanlity,
                Description = p.Description,
                FileDetailsId = p.FileDetailsId,
                Created = p.Created,
                Updated = p.Updated,
            });
            
            products.OrderBy(p => p.Created).ToList();
            if(sortBy != null)
            {
                switch (sortBy)
                {
                    case "price":
                        products = products.OrderBy(p => p.PriceStart);
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

        public AuctionProductModel GetById(long id)
        {
            var product = _context.AuctionProducts.FirstOrDefault(p => p.Id == id);
            if( product != null)
            {
                return new AuctionProductModel()
                {
                    Id = product.Id,
                    AspNetUsersId = product.AspNetUsersId,
                    Author = product.Author,
                    Name = product.Name,
                    PriceStart = product.PriceStart,
                    Quanlity = product.Quanlity,
                    Description = product.Description,
                    FileDetailsId = product.FileDetailsId,
                    IsActive = product.IsActive,
                    Created = product.Created,
                    Updated = product.Updated,
                };
            }
            return null;
        }

        public void Update(AuctionProductModel auctionProductModel)
        {
            var product = _context.AuctionProducts.FirstOrDefault(p => p.Id == auctionProductModel.Id);
            if(product != null)
            {
                product.AspNetUsersId = auctionProductModel.AspNetUsersId;
                product.Author = auctionProductModel.Author;
                product.Name = auctionProductModel.Name;
                product.PriceStart = auctionProductModel.PriceStart;
                product.Quanlity = auctionProductModel.Quanlity;
                product.Description = auctionProductModel.Description;
                product.IsActive = auctionProductModel.IsActive;
                product.Updated = auctionProductModel.Updated;
                _context.Update(product);
                _context.SaveChanges();
            }
           
        }

        public List<AuctionProductModel> GetAllProductByCate()
        {
            var categorizedProducts = _context.AuctionProducts
                                    .Join(_context.ProductCates, p => p.Id, pc => pc.ProductId, (p, pc) => new { p, pc })
                                    .Join(_context.Categories, ppc => ppc.pc.CategoryId, c => c.Id, (ppc, c) => new { ppc, c })
                                    .Select(m => new ProductModel
                                    {
                                        Id = m.ppc.p.Id,
                                        Name = m.ppc.p.Name,
                                        AspNetUsersId = m.ppc.p.AspNetUsersId,
                                        Author = m.ppc.p.Author,
                                        PriceSale = m.ppc.p.PriceStart,
                                        Quanlity = m.ppc.p.Quanlity,
                                        IsActive = m.ppc.p.IsActive,
                                        Updated = m.ppc.p.Updated
        });
            return (List<AuctionProductModel>)categorizedProducts;
        }

        public List<AuctionProductModel> GetCateById(long id)
        {
            List<ProductCate> productCates = _context.ProductCates.Where(c => c.CategoryId == id).ToList();
            if(productCates.Count > 0)
            {
                List<AuctionProductModel> products = new List<AuctionProductModel>();
                foreach (ProductCate productCate in productCates)
                {
                    AuctionProduct product = _context.AuctionProducts.FirstOrDefault(c => c.Id == productCate.Id);
                    AuctionProductModel model = new AuctionProductModel() { 
                        Id = product.Id,
                        AspNetUsersId =product.AspNetUsersId,
                        PriceStart = product.PriceStart,
                        Author = product.Author,
                        Name = product.Name,
                        Description = product.Description,
                        FileDetailsId = product.FileDetailsId,
                        Quanlity = product.Quanlity,
                        IsActive = product.IsActive,
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
