using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Backend.Models;
using NetCore_Backend.Services;

namespace NetCore_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidRepository _bidRepository;
        public BidController(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_bidRepository.GetAll());
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
                var bid = _bidRepository.GetById(id);
                if (bid != null)
                {
                    return Ok(bid);
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
        public IActionResult Update(BidModel bidModel)
        {

            try
            {
                _bidRepository.Update(bidModel);
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
                _bidRepository.Delete(id);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(BidModel bidModel)
        {
            try
            {
                return Ok(_bidRepository.Add(bidModel));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
