using Microsoft.EntityFrameworkCore.ChangeTracking;
using NetCore_Backend.Data;
using NetCore_Backend.Models;

namespace NetCore_Backend.Services.Impl
{
    public class ProductDetailImageImpl : IProductDetailImage
    {
        private readonly MyDbContext _context;
        public ProductDetailImageImpl(MyDbContext context)
        {
            _context = context;
        }

        public string Add(long productId, List<FileUploadModel> fileData)
        {
            if (fileData.Count > 0)
            {
                foreach (FileUploadModel file in fileData)
                {
                    var fileDetails = new FileDetails()
                    {
                        ID = 0,
                        FileName = file.FileDetails.FileName,
                        FileType = file.FileType,
                    };

                    using (var stream = new MemoryStream())
                    {
                        file.FileDetails.CopyTo(stream);
                        fileDetails.FileData = stream.ToArray();
                    }
                    EntityEntry<FileDetails> result = _context.FileDetails.Add(fileDetails);
                    _context.SaveChanges();
                    var productDetailImages = new ProductDetailImage();
                    productDetailImages.FileDetailsId = result.Entity.ID;
                    productDetailImages.ProductId = productId;
                    _context.ProductDetails.Add(productDetailImages);
                    _context.SaveChanges();
                }

                return "Ok";
            }
            
            throw new NotImplementedException();
        }

        public List<long> ListFileIdByProduct(long productId)
        {
            var productDetailImages = _context.ProductDetails.Where(p => p.ProductId == productId).ToList();
            if (productDetailImages.Count > 0)
            {
                List<long> fileIds = new List<long>();
                foreach (var p in productDetailImages)
                {
                    fileIds.Add(p.FileDetailsId);
                }
                return fileIds;
            }
            throw new NotImplementedException();
        }
    }
}
