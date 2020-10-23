using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndGovCo_backendTest_1.Data;
using AndGovCo_backendTest_1.Models;

namespace AndGovCo_backendTest_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDataContext _context;

        public ProductsController(AppDataContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {

            var products = await _context.Products
                .Include(a => a.Area)
                .Include(s => s.ProductState)
                .Include(t => t.ProductType)
                .AsNoTracking()
                .ToListAsync();

            return products;

        }

        // GET: api/Options
        [HttpGet("GetOptions")]
        public async Task<ActionResult> GetOptions()
        {
            var productStates = await _context.ProductStates
                .Where(s => s.State == true)
                .AsNoTracking()
                .ToListAsync();

            var productTypes = await _context.ProductTypes
                .Where(t => t.State == true)
                .AsNoTracking()
                .ToListAsync();

            var areas = await _context.Areas
                .Where(a => a.State == true)
                .AsNoTracking()
                .ToListAsync();

            return Ok(new
            {
                productStates,
                productTypes,
                areas
            });
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            try
            {
                var product = await _context.Products
                .Include(s => s.ProductState)
                .Include(t => t.ProductType)
                .Include(a => a.Area)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ID == id);

                if (product == null)
                {
                    return NotFound();
                }

                return product;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = $"Ha ocurrido un error en el servidor {ex.Message}."
                });
            }
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, Product product)
        {
            if (id != product.ID)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
           
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ID }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(long id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
