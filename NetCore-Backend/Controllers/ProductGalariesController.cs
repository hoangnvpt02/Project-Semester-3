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
    public class ProductGalariesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ProductGalariesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductGalaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductGalary>>> GetProductGalaries()
        {
            return await _context.ProductGalaries.ToListAsync();
        }

        // GET: api/ProductGalaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGalary>> GetProductGalary(long id)
        {
            var productGalary = await _context.ProductGalaries.FindAsync(id);

            if (productGalary == null)
            {
                return NotFound();
            }

            return productGalary;
        }

        // PUT: api/ProductGalaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductGalary(long id, ProductGalary productGalary)
        {
            if (id != productGalary.Id)
            {
                return BadRequest();
            }

            _context.Entry(productGalary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductGalaryExists(id))
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

        // POST: api/ProductGalaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductGalary>> PostProductGalary(ProductGalary productGalary)
        {
            _context.ProductGalaries.Add(productGalary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductGalary", new { id = productGalary.Id }, productGalary);
        }

        // DELETE: api/ProductGalaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductGalary(long id)
        {
            var productGalary = await _context.ProductGalaries.FindAsync(id);
            if (productGalary == null)
            {
                return NotFound();
            }

            _context.ProductGalaries.Remove(productGalary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductGalaryExists(long id)
        {
            return _context.ProductGalaries.Any(e => e.Id == id);
        }
    }
}
