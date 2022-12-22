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
    public class GalariesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public GalariesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Galaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Galary>>> GetGalarys()
        {
            return await _context.Galarys.ToListAsync();
        }

        // GET: api/Galaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Galary>> GetGalary(long id)
        {
            var galary = await _context.Galarys.FindAsync(id);

            if (galary == null)
            {
                return NotFound();
            }

            return galary;
        }

        // PUT: api/Galaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalary(long id, Galary galary)
        {
            if (id != galary.Id)
            {
                return BadRequest();
            }

            _context.Entry(galary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalaryExists(id))
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

        // POST: api/Galaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Galary>> PostGalary(Galary galary)
        {
            _context.Galarys.Add(galary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGalary", new { id = galary.Id }, galary);
        }

        // DELETE: api/Galaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalary(long id)
        {
            var galary = await _context.Galarys.FindAsync(id);
            if (galary == null)
            {
                return NotFound();
            }

            _context.Galarys.Remove(galary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GalaryExists(long id)
        {
            return _context.Galarys.Any(e => e.Id == id);
        }
    }
}
