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
    public class RegistryTributarioTypesController : ControllerBase
    {
        private readonly ProcesoLogisticoContext _context;

        public RegistryTributarioTypesController(ProcesoLogisticoContext context)
        {
            _context = context;
        }

        // GET: api/RegistryTributarioTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistryTributarioType>>> GetRegistryTributarioType()
        {
            return await _context.RegistryTributarioType.ToListAsync();
        }

        // GET: api/RegistryTributarioTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistryTributarioType>> GetRegistryTributarioType(int id)
        {
            var registryTributarioType = await _context.RegistryTributarioType.FindAsync(id);

            if (registryTributarioType == null)
            {
                return NotFound();
            }

            return registryTributarioType;
        }

        // PUT: api/RegistryTributarioTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistryTributarioType(int id, RegistryTributarioType registryTributarioType)
        {
            if (id != registryTributarioType.RegistryTributarioTypeId)
            {
                return BadRequest();
            }

            _context.Entry(registryTributarioType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistryTributarioTypeExists(id))
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

        // POST: api/RegistryTributarioTypes
        [HttpPost]
        public async Task<ActionResult<RegistryTributarioType>> PostRegistryTributarioType(RegistryTributarioType registryTributarioType)
        {
            _context.RegistryTributarioType.Add(registryTributarioType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RegistryTributarioTypeExists(registryTributarioType.RegistryTributarioTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRegistryTributarioType", new { id = registryTributarioType.RegistryTributarioTypeId }, registryTributarioType);
        }

        // DELETE: api/RegistryTributarioTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegistryTributarioType>> DeleteRegistryTributarioType(int id)
        {
            var registryTributarioType = await _context.RegistryTributarioType.FindAsync(id);
            if (registryTributarioType == null)
            {
                return NotFound();
            }

            _context.RegistryTributarioType.Remove(registryTributarioType);
            await _context.SaveChangesAsync();

            return registryTributarioType;
        }

        private bool RegistryTributarioTypeExists(int id)
        {
            return _context.RegistryTributarioType.Any(e => e.RegistryTributarioTypeId == id);
        }
    }
}
