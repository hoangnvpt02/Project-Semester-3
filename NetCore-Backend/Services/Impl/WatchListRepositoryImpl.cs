using NetCore_Backend.Models;
using NetCore_Backend.Data;

namespace NetCore_Backend.Services.Impl
{
    public class WatchListRepositoryImpl : IWatchListRepository
    {
        private readonly MyDbContext _context;
        public WatchListRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }

        public WatchListModel Add(WatchListModel watchListModel)
        {
            var watchList = new WatchList();
            watchList.AspNetUsersId = watchListModel.AspNetUsersId;
            watchList.Name = watchListModel.Name;
            watchList.Description = watchListModel.Description;
            watchList.Created = watchListModel.Created;
            watchList.Updated = watchListModel.Updated;
            watchList.IsActive = watchListModel.IsActive;
            _context.Add(watchList);
            _context.SaveChanges();
            return new WatchListModel()
            {
                Id = watchList.Id,
                AspNetUsersId = watchList.AspNetUsersId,
                Name = watchList.Name,
                Description = watchList.Description,
                IsActive = watchList.IsActive,
                Created = watchList.Created,
                Updated = watchList.Updated,
            };
        }

        public void Delete(long id)
        {
            var watchList = _context.WatchLists.FirstOrDefault(x => x.Id == id);
            if(watchList != null)
            {
                _context.WatchLists.Remove(watchList);
                _context.SaveChanges();
            }
        }

        public List<WatchListModel> GetAll()
        {
            var watchLists = _context.WatchLists.Select(w => new WatchListModel()
            {
                Id = w.Id,
                AspNetUsersId = w.AspNetUsersId,
                Name = w.Name,
                Description = w.Description,
                IsActive = w.IsActive,
                Created = w.Created,
                Updated = w.Updated,
            });
            return watchLists.ToList();
        }

        public WatchListModel GetById(long id)
        {
            var watchList = _context.WatchLists.FirstOrDefault(w => w.Id == id);
            if(watchList != null)
            {
                return new WatchListModel()
                {
                    Id = watchList.Id,
                    AspNetUsersId = watchList.AspNetUsersId,
                    Name = watchList.Name,
                    Description = watchList.Description,
                    IsActive = watchList.IsActive,
                    Created = watchList.Created,
                    Updated = watchList.Updated,

                };
            }
            return null;
        }

        public void Update(WatchListModel watchListModel)
        {
            var watchList = _context.WatchLists.FirstOrDefault(w => w.Id == watchListModel.Id);
            if( watchList != null)
            {
                watchList.AspNetUsersId = watchListModel.AspNetUsersId;
                watchList.Name = watchListModel.Name;
                watchList.Description = watchListModel.Description;
                watchList.IsActive = watchListModel.IsActive;
                watchList.Updated = watchListModel.Updated;
                _context.Update(watchList);
                _context.SaveChanges();
            }
        }
    }
}
