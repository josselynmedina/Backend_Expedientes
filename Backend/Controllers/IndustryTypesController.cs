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
    public class IndustryTypesController : ControllerBase
    {
        private readonly ProcesoLogisticoContext _context;

        public IndustryTypesController(ProcesoLogisticoContext context)
        {
            _context = context;
        }

        // GET: api/IndustryTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IndustryType>>> GetIndustryType()
        {
            return await _context.IndustryType.ToListAsync();
        }

        // GET: api/IndustryTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IndustryType>> GetIndustryType(int id)
        {
            var industryType = await _context.IndustryType.FindAsync(id);

            if (industryType == null)
            {
                return NotFound();
            }

            return industryType;
        }

        // PUT: api/IndustryTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndustryType(int id, IndustryType industryType)
        {
            if (id != industryType.IndustryTypeId)
            {
                return BadRequest();
            }

            _context.Entry(industryType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndustryTypeExists(id))
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

        // POST: api/IndustryTypes
        [HttpPost]
        public async Task<ActionResult<IndustryType>> PostIndustryType(IndustryType industryType)
        {
            _context.IndustryType.Add(industryType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IndustryTypeExists(industryType.IndustryTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIndustryType", new { id = industryType.IndustryTypeId }, industryType);
        }

        // DELETE: api/IndustryTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IndustryType>> DeleteIndustryType(int id)
        {
            var industryType = await _context.IndustryType.FindAsync(id);
            if (industryType == null)
            {
                return NotFound();
            }

            _context.IndustryType.Remove(industryType);
            await _context.SaveChangesAsync();

            return industryType;
        }

        private bool IndustryTypeExists(int id)
        {
            return _context.IndustryType.Any(e => e.IndustryTypeId == id);
        }
    }
}
