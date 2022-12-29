using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using NetCore_Backend.Data;
using NetCore_Backend.Models;
using NetCore_Backend.Services;

namespace NetCore_Backend.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionProductController : ControllerBase
    {
        private readonly IAuctionProductRepository _auctionproductRe;
        public AuctionProductController(IAuctionProductRepository auctionproductRe)
        {
            _auctionproductRe = auctionproductRe;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var product = _auctionproductRe.GetById(id);
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

        [HttpGet]
        public IActionResult GetAll(int start,int end,String ? sortBy)
        {
            try
            {
                return Ok(_auctionproductRe.GetAll(start,end,sortBy));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        [HttpPut]
        public IActionResult Update(AuctionProductModel auctionProductModel)
        {

            try
            {
                _auctionproductRe.Update(auctionProductModel);
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
                _auctionproductRe.Delete(id);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add([FromForm]AuctionProductModel auctionProductModel,  IFormFile fileDetails,FileType fileType)
        {
            try
            {
                return Ok(_auctionproductRe.Add(auctionProductModel, fileDetails,fileType));
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
                return Ok(_auctionproductRe.GetCateById(CategoryId));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

    }
}
