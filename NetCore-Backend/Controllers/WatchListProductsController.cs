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
    public class WatchListProductsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public WatchListProductsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/WatchListProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WatchListProduct>>> GetWatchListProducts()
        {
            return await _context.WatchListProducts.ToListAsync();
        }

        // GET: api/WatchListProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WatchListProduct>> GetWatchListProduct(long id)
        {
            var watchListProduct = await _context.WatchListProducts.FindAsync(id);

            if (watchListProduct == null)
            {
                return NotFound();
            }

            return watchListProduct;
        }

        // PUT: api/WatchListProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWatchListProduct(long id, WatchListProduct watchListProduct)
        {
            if (id != watchListProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(watchListProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchListProductExists(id))
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

        // POST: api/WatchListProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WatchListProduct>> PostWatchListProduct(WatchListProduct watchListProduct)
        {
            _context.WatchListProducts.Add(watchListProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWatchListProduct", new { id = watchListProduct.Id }, watchListProduct);
        }

        // DELETE: api/WatchListProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWatchListProduct(long id)
        {
            var watchListProduct = await _context.WatchListProducts.FindAsync(id);
            if (watchListProduct == null)
            {
                return NotFound();
            }

            _context.WatchListProducts.Remove(watchListProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WatchListProductExists(long id)
        {
            return _context.WatchListProducts.Any(e => e.Id == id);
        }
    }
}
