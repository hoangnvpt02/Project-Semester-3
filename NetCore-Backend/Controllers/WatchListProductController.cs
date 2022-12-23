using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Backend.Models;
using NetCore_Backend.Services;
namespace NetCore_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchListProductController : ControllerBase
    {
        private readonly IWatchListProductRepository _watchListProductRepository;
        public WatchListProductController(IWatchListProductRepository watchListProductRepository)
        {
            _watchListProductRepository = watchListProductRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_watchListProductRepository.GetAll());
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
                var watchListProduct = _watchListProductRepository.GetById(id);
                if (watchListProduct != null)
                {
                    return Ok(watchListProduct);
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
        [HttpPut("{id}")]
        public IActionResult Update(WatchListProductModel watchListProductModel)
        {

            try
            {
                _watchListProductRepository.Update(watchListProductModel);
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
                _watchListProductRepository.Delete(id);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(WatchListProductModel watchListProductModel)
        {
            try
            {
                return Ok(_watchListProductRepository.Add(watchListProductModel));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
