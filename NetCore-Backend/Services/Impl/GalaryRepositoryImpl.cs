using NetCore_Backend.Data;
using NetCore_Backend.Models;

namespace NetCore_Backend.Services.Impl
{
    public class GalaryRepositoryImpl : IGalaryRepository
    {
        private readonly MyDbContext _context;
        public GalaryRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }

        public List<GalaryModel> GetAll()
        {
            var galaryList = _context.Galarys.Select(g => new GalaryModel()
            {
                Id = g.Id,
                AspNetUsersId = g.AspNetUsersId,
                FromDate = g.FromDate,
                ToDate = g.ToDate,
                Authen = g.Authen,
                Address = g.Address,
                Discription = g.Discription,
                IsActive = g.IsActive,
                CreeateDate = g.CreeateDate,
                UpdatedDate = g.UpdatedDate,
            });
            return galaryList.ToList();
        }

        public GalaryModel GetById(long id)
        {
            var g = _context.Galarys.FirstOrDefault(ga => ga.Id == id);
            return new GalaryModel()
            {
                
                AspNetUsersId = g.AspNetUsersId,
                FromDate = g.FromDate,
                ToDate = g.ToDate,
                Authen = g.Authen,
                Address = g.Address,
                Discription = g.Discription,
                IsActive = g.IsActive,
                CreeateDate = g.CreeateDate,
                UpdatedDate = g.UpdatedDate,
            };
        }

        public GalaryModel Add(GalaryModel galary)
        {
            var _galary = new Galary()
            {
                Id = galary.Id,
                AspNetUsersId = galary.AspNetUsersId,
                FromDate = galary.FromDate,
                ToDate = galary.ToDate,
                Authen = galary.Authen,
                Address = galary.Address,
                Discription = galary.Discription,
                IsActive = galary.IsActive,
                CreeateDate = galary.CreeateDate,
                UpdatedDate = galary.UpdatedDate,
            };
            _context.Galarys.Add(_galary);
            _context.SaveChanges();
            return new GalaryModel()
            {
                Id = _galary.Id,
                AspNetUsersId = _galary.AspNetUsersId,
                FromDate = _galary.FromDate,
                ToDate = _galary.ToDate,
                Authen = _galary.Authen,
                Address = _galary.Address,
                Discription = _galary.Discription,
                IsActive = _galary.IsActive,
                CreeateDate = _galary.CreeateDate,
                UpdatedDate = _galary.UpdatedDate,
            };

        }

        public void Update(GalaryModel galary)
        {
            var _galary = _context.Galarys.FirstOrDefault(g => g.Id == galary.Id);
            _galary.FromDate = galary.FromDate;
            _galary.ToDate = galary.ToDate;
            _galary.Authen = galary.Authen;
            _galary.Address = galary.Address;
            _galary.Discription = galary.Discription;
            _galary.IsActive = galary.IsActive;
            _galary.UpdatedDate = galary.UpdatedDate;
            _context.Update(_galary);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var galary = _context.Galarys.FirstOrDefault(g => g.Id == id);
            if (galary != null)
            {
                _context.Remove(galary);
                _context.SaveChanges();
            }
        }

        public List<ProductModel> GetProductByGalaryId(long galaryId)
        {
            if (galaryId > 0)
            {
                var productGalarys = _context.ProductGalaries.Where(p => p.GalaryId == galaryId).ToList();
                if (productGalarys.Count > 0)
                {
                    List<ProductModel> productModels = new List<ProductModel>();
                    foreach (var productGalary in productGalarys)
                    {
                        Product product = _context.Products.Where(p => p.Id == productGalary.ProductId).FirstOrDefault();
                        if (product != null)
                        {
                            ProductModel model = new ProductModel()
                            {
                                Id = product.Id,
                                AspNetUsersId = product.AspNetUsersId,
                                CountryId = product.CountryId,
                                Price = product.Price,
                                Author = product.Author,
                                Name = product.Name,
                                ManufactureYear = product.ManufactureYear,
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
                            productModels.Add(model);
                        }
                    }

                    return productModels;
                }
            }
            throw new NotImplementedException();
        }
    }
}
