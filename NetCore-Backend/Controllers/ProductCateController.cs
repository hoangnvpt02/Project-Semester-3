using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Backend.Models;
using NetCore_Backend.Services;

namespace NetCore_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCateController : ControllerBase
    {
        private readonly IProductCateRepository _productCateRepository;
        public ProductCateController(IProductCateRepository productCateRepository)
        {
            _productCateRepository = productCateRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_productCateRepository.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var productCate = _productCateRepository.GetById(id);
                if (productCate != null)
                {
                    return Ok(productCate);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("/cate/product-id/{productId}")]
        public IActionResult getByProductId(long productId)
        {
            try
            {
                var productCate = _productCateRepository.getByProductId(productId);
                if (productCate != null)
                {
                    return Ok(productCate);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Update(ProductCateModel productCateModel)
        {

            try
            {
                _productCateRepository.Update(productCateModel);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _productCateRepository.Delete(id);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(ProductCateModel productCateModel)
        {
            try
            {
                return Ok(_productCateRepository.Add(productCateModel));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
