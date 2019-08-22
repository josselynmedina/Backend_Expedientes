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
    public class GroupPeoplesController : ControllerBase
    {
        private readonly ProcesoLogisticoContext _context;

        public GroupPeoplesController(ProcesoLogisticoContext context)
        {
            _context = context;
        }

        // GET: api/GroupPeoples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupPeople>>> GetGroupPeople()
        {
            return await _context.GroupPeople.ToListAsync();
        }

        // GET: api/GroupPeoples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupPeople>> GetGroupPeople(int id)
        {
            var groupPeople = await _context.GroupPeople.FindAsync(id);

            if (groupPeople == null)
            {
                return NotFound();
            }

            return groupPeople;
        }

        // PUT: api/GroupPeoples/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupPeople(int id, GroupPeople groupPeople)
        {
            if (id != groupPeople.GroupPeopleId)
            {
                return BadRequest();
            }

            _context.Entry(groupPeople).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupPeopleExists(id))
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

        // POST: api/GroupPeoples
        [HttpPost]
        public async Task<ActionResult<GroupPeople>> PostGroupPeople(GroupPeople groupPeople)
        {
            _context.GroupPeople.Add(groupPeople);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GroupPeopleExists(groupPeople.GroupPeopleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGroupPeople", new { id = groupPeople.GroupPeopleId }, groupPeople);
        }

        // DELETE: api/GroupPeoples/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupPeople>> DeleteGroupPeople(int id)
        {
            var groupPeople = await _context.GroupPeople.FindAsync(id);
            if (groupPeople == null)
            {
                return NotFound();
            }

            _context.GroupPeople.Remove(groupPeople);
            await _context.SaveChangesAsync();

            return groupPeople;
        }

        private bool GroupPeopleExists(int id)
        {
            return _context.GroupPeople.Any(e => e.GroupPeopleId == id);
        }
    }
}
