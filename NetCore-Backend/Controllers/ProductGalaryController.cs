using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Backend.Models;
using NetCore_Backend.Services;

namespace NetCore_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGalaryController : ControllerBase
    {
        private readonly IProductGalaryRepository _productGalaryRepository;
        public ProductGalaryController(IProductGalaryRepository productGalaryRepository)
        {
            _productGalaryRepository = productGalaryRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_productGalaryRepository.GetAll());
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
                var productGalary = _productGalaryRepository.GetById(id);
                if (productGalary != null)
                {
                    return Ok(productGalary);
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
        public IActionResult Update(ProductGalaryModel productGalaryModel)
        {
            try
            {
                _productGalaryRepository.Update(productGalaryModel);
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
                _productGalaryRepository.Delete(id);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(ProductGalaryModel productGalaryModel)
        {
            try
            {
                return Ok(_productGalaryRepository.Add(productGalaryModel));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
