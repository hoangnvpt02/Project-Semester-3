using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Backend.Models;
using NetCore_Backend.Services;

namespace NetCore_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_countryRepository.GetAll());
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
                var country = _countryRepository.GetById(id);
                if (country != null)
                {
                    return Ok(country);
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
        public IActionResult Update(long id,CountryResultModel countryResult)
        {
           
            try
            {
               _countryRepository.Update(countryResult,id);
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
                _countryRepository.Delete(id);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(CountryResultModel country)
        {
            try
            {
                return Ok(_countryRepository.Add(country));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
