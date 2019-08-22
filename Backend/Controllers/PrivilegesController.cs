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
    public class PrivilegesController : ControllerBase
    {
        private readonly ProcesoLogisticoContext _context;

        public PrivilegesController(ProcesoLogisticoContext context)
        {
            _context = context;
        }

        // GET: api/Privileges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Privilege>>> GetPrivilege()
        {
            return await _context.Privilege.ToListAsync();
        }

        // GET: api/Privileges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Privilege>> GetPrivilege(int id)
        {
            var privilege = await _context.Privilege.FindAsync(id);

            if (privilege == null)
            {
                return NotFound();
            }

            return privilege;
        }

        // PUT: api/Privileges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrivilege(int id, Privilege privilege)
        {
            if (id != privilege.PrivilegeId)
            {
                return BadRequest();
            }

            _context.Entry(privilege).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrivilegeExists(id))
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

        // POST: api/Privileges
        [HttpPost]
        public async Task<ActionResult<Privilege>> PostPrivilege(Privilege privilege)
        {
            _context.Privilege.Add(privilege);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrivilegeExists(privilege.PrivilegeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPrivilege", new { id = privilege.PrivilegeId }, privilege);
        }

        // DELETE: api/Privileges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Privilege>> DeletePrivilege(int id)
        {
            var privilege = await _context.Privilege.FindAsync(id);
            if (privilege == null)
            {
                return NotFound();
            }

            _context.Privilege.Remove(privilege);
            await _context.SaveChangesAsync();

            return privilege;
        }

        private bool PrivilegeExists(int id)
        {
            return _context.Privilege.Any(e => e.PrivilegeId == id);
        }
    }
}
