using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Backend.Models;
using NetCore_Backend.Services;

namespace NetCore_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DossierController : ControllerBase
    {
        private readonly IDossierRepository _dossierRepository;
        public DossierController(IDossierRepository dossierRepository)
        {
            _dossierRepository = dossierRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_dossierRepository.GetAll());
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
                var dossier = _dossierRepository.GetById(id);
                if (dossier != null)
                {
                    return Ok(dossier);
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
        public IActionResult Update(DossierModel dossierModel)
        {

            try
            {
                _dossierRepository.Update(dossierModel);
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
                _dossierRepository.Delete(id);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(DossierModel dossierModel)
        {
            try
            {
                return Ok(_dossierRepository.Add(dossierModel));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
