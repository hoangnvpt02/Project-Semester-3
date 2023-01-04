using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface IProductDetailImage
    {
        string Add(long productId, List<FileUploadModel> fileData);
        List<long> ListFileIdByProduct(long productId);

    }
}
