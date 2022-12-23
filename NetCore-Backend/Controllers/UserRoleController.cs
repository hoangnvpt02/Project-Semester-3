using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Backend.Models;
using NetCore_Backend.Services;

namespace NetCore_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleRepository _userRoleRepository;
        public UserRoleController(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userRoleRepository.GetAll());
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
                var userRole = _userRoleRepository.GetById(id);
                if (userRole != null)
                {
                    return Ok(userRole);
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
        public IActionResult Update(UserRoleModel userRoleModel)
        {

            try
            {
                _userRoleRepository.Update(userRoleModel);
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
                _userRoleRepository.Delete(id);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(UserRoleModel userRoleModel)
        {
            try
            {
                return Ok(_userRoleRepository.Add(userRoleModel));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
