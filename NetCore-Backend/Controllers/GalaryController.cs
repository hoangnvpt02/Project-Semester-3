using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Backend.Models;
using NetCore_Backend.Services;

namespace NetCore_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalaryController : ControllerBase
    {
        private readonly IGalaryRepository _galaryRepository;
        public GalaryController(IGalaryRepository galaryRepository)
        {
            _galaryRepository = galaryRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_galaryRepository.GetAll());
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
                var galary = _galaryRepository.GetById(id);
                if (galary != null)
                {
                    return Ok(galary);
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
        public IActionResult Update(GalaryModel galaryModel)
        {

            try
            {
                _galaryRepository.Update(galaryModel);
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
                _galaryRepository.Delete(id);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(GalaryModel galaryModel)
        {
            try
            {
                return Ok(_galaryRepository.Add(galaryModel));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
