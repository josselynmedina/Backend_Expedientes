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
    public class RolPrivilegesController : ControllerBase
    {
        private readonly ProcesoLogisticoContext _context;

        public RolPrivilegesController(ProcesoLogisticoContext context)
        {
            _context = context;
        }

        // GET: api/RolPrivileges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolPrivilege>>> GetRolPrivilege()
        {
            return await _context.RolPrivilege.ToListAsync();
        }

        // GET: api/RolPrivileges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolPrivilege>> GetRolPrivilege(int id)
        {
            var rolPrivilege = await _context.RolPrivilege.FindAsync(id);

            if (rolPrivilege == null)
            {
                return NotFound();
            }

            return rolPrivilege;
        }

        // PUT: api/RolPrivileges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolPrivilege(int id, RolPrivilege rolPrivilege)
        {
            if (id != rolPrivilege.RolId)
            {
                return BadRequest();
            }

            _context.Entry(rolPrivilege).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolPrivilegeExists(id))
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

        // POST: api/RolPrivileges
        [HttpPost]
        public async Task<ActionResult<RolPrivilege>> PostRolPrivilege(RolPrivilege rolPrivilege)
        {
            _context.RolPrivilege.Add(rolPrivilege);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RolPrivilegeExists(rolPrivilege.RolId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRolPrivilege", new { id = rolPrivilege.RolId }, rolPrivilege);
        }

        // DELETE: api/RolPrivileges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RolPrivilege>> DeleteRolPrivilege(int id)
        {
            var rolPrivilege = await _context.RolPrivilege.FindAsync(id);
            if (rolPrivilege == null)
            {
                return NotFound();
            }

            _context.RolPrivilege.Remove(rolPrivilege);
            await _context.SaveChangesAsync();

            return rolPrivilege;
        }

        private bool RolPrivilegeExists(int id)
        {
            return _context.RolPrivilege.Any(e => e.RolId == id);
        }
    }
}
