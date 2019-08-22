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
    public class TypeFiscalsController : ControllerBase
    {
        private readonly ProcesoLogisticoContext _context;

        public TypeFiscalsController(ProcesoLogisticoContext context)
        {
            _context = context;
        }

        // GET: api/TypeFiscals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeFiscal>>> GetTypeFiscal()
        {
            return await _context.TypeFiscal.ToListAsync();
        }

        // GET: api/TypeFiscals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeFiscal>> GetTypeFiscal(int id)
        {
            var typeFiscal = await _context.TypeFiscal.FindAsync(id);

            if (typeFiscal == null)
            {
                return NotFound();
            }

            return typeFiscal;
        }

        // PUT: api/TypeFiscals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeFiscal(int id, TypeFiscal typeFiscal)
        {
            if (id != typeFiscal.TypeFiscalId)
            {
                return BadRequest();
            }

            _context.Entry(typeFiscal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeFiscalExists(id))
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

        // POST: api/TypeFiscals
        [HttpPost]
        public async Task<ActionResult<TypeFiscal>> PostTypeFiscal(TypeFiscal typeFiscal)
        {
            _context.TypeFiscal.Add(typeFiscal);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TypeFiscalExists(typeFiscal.TypeFiscalId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTypeFiscal", new { id = typeFiscal.TypeFiscalId }, typeFiscal);
        }

        // DELETE: api/TypeFiscals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeFiscal>> DeleteTypeFiscal(int id)
        {
            var typeFiscal = await _context.TypeFiscal.FindAsync(id);
            if (typeFiscal == null)
            {
                return NotFound();
            }

            _context.TypeFiscal.Remove(typeFiscal);
            await _context.SaveChangesAsync();

            return typeFiscal;
        }

        private bool TypeFiscalExists(int id)
        {
            return _context.TypeFiscal.Any(e => e.TypeFiscalId == id);
        }
    }
}
