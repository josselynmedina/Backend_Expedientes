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
    public class InconsistenciesController : ControllerBase
    {
        private readonly ProcesoLogisticoContext _context;

        public InconsistenciesController(ProcesoLogisticoContext context)
        {
            _context = context;
        }

        // GET: api/Inconsistencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inconsistency>>> GetInconsistency()
        {
            return await _context.Inconsistency.ToListAsync();
        }

        // GET: api/Inconsistencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inconsistency>> GetInconsistency(int id)
        {
            var inconsistency = await _context.Inconsistency.FindAsync(id);

            if (inconsistency == null)
            {
                return NotFound();
            }

            return inconsistency;
        }

        // PUT: api/Inconsistencies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInconsistency(int id, Inconsistency inconsistency)
        {
            if (id != inconsistency.InconsistencyId)
            {
                return BadRequest();
            }

            _context.Entry(inconsistency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InconsistencyExists(id))
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

        // POST: api/Inconsistencies
        [HttpPost]
        public async Task<ActionResult<Inconsistency>> PostInconsistency(Inconsistency inconsistency)
        {
            _context.Inconsistency.Add(inconsistency);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInconsistency", new { id = inconsistency.InconsistencyId }, inconsistency);
        }

        // DELETE: api/Inconsistencies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Inconsistency>> DeleteInconsistency(int id)
        {
            var inconsistency = await _context.Inconsistency.FindAsync(id);
            if (inconsistency == null)
            {
                return NotFound();
            }

            _context.Inconsistency.Remove(inconsistency);
            await _context.SaveChangesAsync();

            return inconsistency;
        }

        private bool InconsistencyExists(int id)
        {
            return _context.Inconsistency.Any(e => e.InconsistencyId == id);
        }
    }
}
