using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Backend.Models;
using NetCore_Backend.Services;

namespace NetCore_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchListController : ControllerBase
    {
        private readonly IWatchListRepository _watchListRepository;
        public WatchListController(IWatchListRepository watchListRepository)
        {
            _watchListRepository = watchListRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_watchListRepository.GetAll());
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
                var watchList = _watchListRepository.GetById(id);
                if (watchList != null)
                {
                    return Ok(watchList);
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
        public IActionResult Update(WatchListModel watchListModel)
        {

            try
            {
                _watchListRepository.Update(watchListModel);
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
                _watchListRepository.Delete(id);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(WatchListModel watchListModel)
        {
            try
            {
                return Ok(_watchListRepository.Add(watchListModel));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
