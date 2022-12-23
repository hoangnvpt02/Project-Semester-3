using NetCore_Backend.Models;
using NetCore_Backend.Data;

namespace NetCore_Backend.Services.Impl
{
    public class BidRepositoryImpl : IBidRepository
    {
        private readonly MyDbContext _content;
        public BidRepositoryImpl(MyDbContext content)
        {
            _content = content;
        }

        public BidModel Add(BidModel bidModel)
        {
            var bid = new Bid();
            bid.UserId = bidModel.UserId;
            bid.ProductId = bidModel.ProductId;
            bid.GalaryId = bidModel.GalaryId;
            bid.DidTime = bidModel.DidTime;
            bid.Price = bidModel.Price;
            bid.IsActive = bidModel.IsActive;
            _content.Add(bid);
            _content.SaveChanges();
            return new BidModel()
            {
                Id = bid.Id,
                UserId = bid.UserId,
                ProductId = bid.ProductId,
                GalaryId = bid.GalaryId,
                DidTime = bid.DidTime,
                Price = bid.Price,
                IsActive = bid.IsActive,
            };
        }

        public void Delete(long id)
        {
            var bid = _content.Bid.FirstOrDefault(x => x.Id == id);
            if(bid != null)
            {
                _content.Remove(bid);
                _content.SaveChanges();
            }
        }

        public List<BidModel> GetAll()
        {
            var bids = _content.Bid.Select(b => new BidModel()
            {
                Id = b.Id,
                UserId = b.UserId,
                ProductId = b.ProductId,
                GalaryId = b.GalaryId,
                DidTime = b.DidTime,
                Price = b.Price,
                IsActive = b.IsActive,
            });
            return bids.ToList();
        }

        public BidModel GetById(long id)
        {
            var b = _content.Bid.FirstOrDefault(b => b.Id == id);
            if(b != null)
            {
                return new BidModel()
                {
                    Id = b.Id,
                    UserId = b.UserId,
                    ProductId = b.ProductId,
                    GalaryId = b.GalaryId,
                    DidTime = b.DidTime,
                    Price = b.Price,
                    IsActive = b.IsActive,
                };
            }
            return null;
        }

        public void Update(BidModel bidModel)
        {
            var bid = _content.Bid.FirstOrDefault(b => b.Id == bidModel.Id);
            if(bid != null)
            {
                bid.UserId = bidModel.UserId;
                bid.ProductId = bidModel.ProductId;
                bid.GalaryId = bidModel.GalaryId;
                bid.Price = bidModel.Price;
                bid.IsActive = bidModel.IsActive;
                bid.DidTime = bidModel.DidTime;
                _content.Update(bid);
                _content.SaveChanges();
            }
        }
    }
}
