using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface IAuctionProductRepository
    {
        List<AuctionProductModel> GetAll(int start,int end,String ? sortBy);
        List<AuctionProductModel> GetAllProductByCate();
        AuctionProductModel GetById(long id);
        AuctionProductModel Add(AuctionProductModel auctionProductModel, IFormFile fileData, FileType fileType);
        void Update(AuctionProductModel auctionProductModel);
        void Delete(long id);

        List<AuctionProductModel> GetCateById(long id);
    }
}
