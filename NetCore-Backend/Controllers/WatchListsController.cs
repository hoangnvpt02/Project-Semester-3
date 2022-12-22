using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore_Backend.Data;

namespace NetCore_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchListsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public WatchListsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/WatchLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WatchList>>> GetWatchLists()
        {
            return await _context.WatchLists.ToListAsync();
        }

        // GET: api/WatchLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WatchList>> GetWatchList(long id)
        {
            var watchList = await _context.WatchLists.FindAsync(id);

            if (watchList == null)
            {
                return NotFound();
            }

            return watchList;
        }

        // PUT: api/WatchLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWatchList(long id, WatchList watchList)
        {
            if (id != watchList.Id)
            {
                return BadRequest();
            }

            _context.Entry(watchList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WatchLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WatchList>> PostWatchList(WatchList watchList)
        {
            _context.WatchLists.Add(watchList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWatchList", new { id = watchList.Id }, watchList);
        }

        // DELETE: api/WatchLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWatchList(long id)
        {
            var watchList = await _context.WatchLists.FindAsync(id);
            if (watchList == null)
            {
                return NotFound();
            }

            _context.WatchLists.Remove(watchList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WatchListExists(long id)
        {
            return _context.WatchLists.Any(e => e.Id == id);
        }
    }
}
