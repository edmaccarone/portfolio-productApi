using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            // Fetch all products from the database
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            // Look up product by ID
            var product = await _context.Products.FindAsync(id);

            // Return 404 if not found
            if (product == null)
            {
                return NotFound();
            }

            return product; // 200 OK with product data
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            // Add new product to the DB
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // Return 201 Created + Location header
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            // ID mismatch check
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(); // Save updated record
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(e => e.Id == id))
                {
                    return NotFound(); // Product no longer exists
                }

                throw; // Bubble up if it's another error
            }

            return NoContent(); // 204 No Content
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // Look up product
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound(); // 404
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent(); // 204 No Content
        }
    }
}
