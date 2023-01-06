using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Backend.Models;
using NetCore_Backend.Services;

namespace NetCore_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailImageController : ControllerBase
    {
        private readonly IProductDetailImage _detailImage;
        public ProductDetailImageController(IProductDetailImage detailImage)
        {
            _detailImage = detailImage;
        }
        [HttpPost("{productId}")]
        public IActionResult Add( long productId, [FromForm] List<FileUploadModel> fileData)
        {
            try
            {
                return Ok(_detailImage.Add(productId,fileData));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult List(long productId)
        {
            try
            {
                List<long> result = new List<long>();
                result = _detailImage.ListFileIdByProduct(productId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
