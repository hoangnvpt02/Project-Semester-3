using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface IBidRepository
    {
        List<BidModel> GetAll();
        BidModel GetById(long id);
        BidModel Add(BidModel bidModel);
        void Update(BidModel bidModel);
        void Delete(long id);
    }
}
