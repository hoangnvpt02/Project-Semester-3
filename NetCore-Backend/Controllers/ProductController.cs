using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using NetCore_Backend.Data;
using NetCore_Backend.Models;
using NetCore_Backend.Services;

namespace NetCore_Backend.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly UserManager<IdentityUser> _userManager;
        public ProductController(IProductRepository productRepository, UserManager<IdentityUser> userManager)
        {
            _productRepository = productRepository;
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var product = _productRepository.GetById(id);
                if (product != null)
                {
                    return Ok(product);
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

        [HttpGet("/cate")]
        public IActionResult GetAllProductByCate(long id)
        {
            try
            {
                var product = _productRepository.GetAllProductByCate();
                if (product != null)
                {
                    return Ok(product);
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

        //[HttpGet, Authorize(Roles = UserRoles.User)]
        [HttpGet]
        public IActionResult GetAll(int start,int end,String ? sortBy)
        {
            try
            {
                return Ok(_productRepository.GetAll(start,end,sortBy));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        [HttpPut]
        public IActionResult Update(ProductModel productModel)
        {

            try
            {
                _productRepository.Update(productModel);
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
                _productRepository.Delete(id);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost, Authorize(Roles = UserRoles.User)]
        public IActionResult Add([FromForm]ProductModel productModel,  IFormFile fileDetails,FileType fileType)
        {
            try
            {
                var id = _userManager.GetUserId(User);
                return Ok(_productRepository.Add(productModel, fileDetails,fileType,id));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpGet("CategoryId")]
        
        public IActionResult ListByCategory(long CategoryId)
        {

            try
            {
                return Ok(_productRepository.GetCateById(CategoryId));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("feature")]

        public IActionResult GetAllProductByFeature ()
        {

            try
            {
                return Ok(_productRepository.GetAllProductByFeature());
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("sale")]

        public IActionResult GetAllProductBySale()
        {

            try
            {
                return Ok(_productRepository.GetAllProductBySale());
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
