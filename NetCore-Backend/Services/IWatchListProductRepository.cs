using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface IWatchListProductRepository
    {
        List<WatchListProductModel> GetAll();
        WatchListProductModel GetById(long id);
        WatchListProductModel Add(WatchListProductModel watchListProductModel);
        void Update(WatchListProductModel watchListProductModel);
        void Delete(long id);
    }
}
