using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Model;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductLinesController : ControllerBase
    {
        private readonly ProcesoLogisticoContext _context;

        public ProductLinesController(ProcesoLogisticoContext context)
        {
            _context = context;
        }

        // GET: api/ProductLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductLine>>> GetProductLine()
        {
            return await _context.ProductLine.ToListAsync();
        }

        // GET: api/ProductLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductLine>> GetProductLine(int id)
        {
            var productLine = await _context.ProductLine.FindAsync(id);

            if (productLine == null)
            {
                return NotFound();
            }

            return productLine;
        }

        // PUT: api/ProductLines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductLine(int id, ProductLine productLine)
        {
            if (id != productLine.ProductLineId)
            {
                return BadRequest();
            }

            _context.Entry(productLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductLineExists(id))
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

        // POST: api/ProductLines
        [HttpPost]
        public async Task<ActionResult<ProductLine>> PostProductLine(ProductLine productLine)
        {
            _context.ProductLine.Add(productLine);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductLineExists(productLine.ProductLineId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductLine", new { id = productLine.ProductLineId }, productLine);
        }

        // DELETE: api/ProductLines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductLine>> DeleteProductLine(int id)
        {
            var productLine = await _context.ProductLine.FindAsync(id);
            if (productLine == null)
            {
                return NotFound();
            }

            _context.ProductLine.Remove(productLine);
            await _context.SaveChangesAsync();

            return productLine;
        }

        private bool ProductLineExists(int id)
        {
            return _context.ProductLine.Any(e => e.ProductLineId == id);
        }
    }
}
