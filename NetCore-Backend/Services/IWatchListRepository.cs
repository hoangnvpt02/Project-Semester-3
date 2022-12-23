using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface IWatchListRepository
    {
        List<WatchListModel> GetAll();
        WatchListModel GetById(long id);
        WatchListModel Add(WatchListModel watchListModel);
        void Update(WatchListModel watchListModel);
        void Delete(long id);
    }
}
