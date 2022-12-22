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
    public class ProductCatesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ProductCatesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductCates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCate>>> GetProductCates()
        {
            return await _context.ProductCates.ToListAsync();
        }

        // GET: api/ProductCates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCate>> GetProductCate(long id)
        {
            var productCate = await _context.ProductCates.FindAsync(id);

            if (productCate == null)
            {
                return NotFound();
            }

            return productCate;
        }

        // PUT: api/ProductCates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCate(long id, ProductCate productCate)
        {
            if (id != productCate.Id)
            {
                return BadRequest();
            }

            _context.Entry(productCate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCateExists(id))
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

        // POST: api/ProductCates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductCate>> PostProductCate(ProductCate productCate)
        {
            _context.ProductCates.Add(productCate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductCate", new { id = productCate.Id }, productCate);
        }

        // DELETE: api/ProductCates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCate(long id)
        {
            var productCate = await _context.ProductCates.FindAsync(id);
            if (productCate == null)
            {
                return NotFound();
            }

            _context.ProductCates.Remove(productCate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductCateExists(long id)
        {
            return _context.ProductCates.Any(e => e.Id == id);
        }
    }
}
