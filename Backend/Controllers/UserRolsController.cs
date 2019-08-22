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
    public class UserRolsController : ControllerBase
    {
        private readonly ProcesoLogisticoContext _context;

        public UserRolsController(ProcesoLogisticoContext context)
        {
            _context = context;
        }

        // GET: api/UserRols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRol>>> GetUserRol()
        {
            return await _context.UserRol.ToListAsync();
        }

        // GET: api/UserRols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRol>> GetUserRol(int id)
        {
            var userRol = await _context.UserRol.FindAsync(id);

            if (userRol == null)
            {
                return NotFound();
            }

            return userRol;
        }

        // PUT: api/UserRols/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRol(int id, UserRol userRol)
        {
            if (id != userRol.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userRol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRolExists(id))
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

        // POST: api/UserRols
        [HttpPost]
        public async Task<ActionResult<UserRol>> PostUserRol(UserRol userRol)
        {
            _context.UserRol.Add(userRol);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserRolExists(userRol.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserRol", new { id = userRol.UserId }, userRol);
        }

        // DELETE: api/UserRols/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserRol>> DeleteUserRol(int id)
        {
            var userRol = await _context.UserRol.FindAsync(id);
            if (userRol == null)
            {
                return NotFound();
            }

            _context.UserRol.Remove(userRol);
            await _context.SaveChangesAsync();

            return userRol;
        }

        private bool UserRolExists(int id)
        {
            return _context.UserRol.Any(e => e.UserId == id);
        }
    }
}
