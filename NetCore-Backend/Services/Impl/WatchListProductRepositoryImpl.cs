using NetCore_Backend.Models;
using NetCore_Backend.Data;
namespace NetCore_Backend.Services.Impl
{
    public class WatchListProductRepositoryImpl : IWatchListProductRepository
    {
        private readonly MyDbContext _context;
        public WatchListProductRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }

        public WatchListProductModel Add(WatchListProductModel watchListProductModel)
        {
            var watchListProduct = new WatchListProduct();
            watchListProduct.ProductId = watchListProductModel.ProductId;
            watchListProduct.WatchListId = watchListProductModel.WatchListId;
            watchListProduct.IsActive = watchListProductModel.IsActive;
            watchListProduct.Created = watchListProductModel.Created;
            watchListProduct.Updated = watchListProductModel.Updated;
            _context.Add(watchListProduct);
            _context.SaveChanges();
            return new WatchListProductModel()
            {
                Id = watchListProduct.Id,
                WatchListId = watchListProduct.WatchListId,
                ProductId = watchListProduct.ProductId,
                IsActive = watchListProduct.IsActive,
                Created = watchListProduct.Created,
                Updated = watchListProduct.Updated,
            };
        }

        public void Delete(long id)
        {
            var watchListProduct = _context.WatchListProducts.FirstOrDefault(x => x.Id == id);
            if(watchListProduct != null)
            {
                watchListProduct.IsActive = 1;
                _context.SaveChanges();
            }
        }

        public List<WatchListProductModel> GetAll()
        {
            var watchListProducts = _context.WatchListProducts.Where(w => w.IsActive == 0).Select(w => new WatchListProductModel() { 
                Id = w.Id,
                WatchListId = w.WatchListId,
                ProductId = w.ProductId,
                IsActive = w.IsActive,
                Created = w.Created,
                Updated = w.Updated,
            });
            return watchListProducts.ToList();
        }

        public WatchListProductModel GetById(long id)
        {
            var watchListProduct = _context.WatchListProducts.FirstOrDefault(w => w.Id == id);
            if(watchListProduct != null)
            {
                return new WatchListProductModel()
                {
                    Id = watchListProduct.Id,
                    WatchListId = watchListProduct.WatchListId,
                    ProductId = watchListProduct.ProductId,
                    IsActive = watchListProduct.IsActive,
                    Created = watchListProduct.Created,
                    Updated = watchListProduct.Updated,
                };
            }
            return null;
        }

        public void Update(WatchListProductModel watchListProductModel)
        {
            var watchListProduct = _context.WatchListProducts.FirstOrDefault(w => w.Id == watchListProductModel.Id);
            if(watchListProduct != null)
            {
                watchListProduct.WatchListId = watchListProductModel.WatchListId;
                watchListProduct.ProductId = watchListProductModel.ProductId;
                watchListProduct.IsActive = watchListProductModel.IsActive;
                watchListProduct.Updated = watchListProductModel.Updated;
                _context.Update(watchListProduct);
                _context.SaveChanges();
            }
        }
    }
}
