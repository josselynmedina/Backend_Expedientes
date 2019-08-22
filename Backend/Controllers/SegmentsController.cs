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
    public class SegmentsController : ControllerBase
    {
        private readonly ProcesoLogisticoContext _context;

        public SegmentsController(ProcesoLogisticoContext context)
        {
            _context = context;
        }

        // GET: api/Segments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Segment>>> GetSegment()
        {
            return await _context.Segment.ToListAsync();
        }

        // GET: api/Segments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Segment>> GetSegment(int id)
        {
            var segment = await _context.Segment.FindAsync(id);

            if (segment == null)
            {
                return NotFound();
            }

            return segment;
        }

        // PUT: api/Segments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSegment(int id, Segment segment)
        {
            if (id != segment.SegmentId)
            {
                return BadRequest();
            }

            _context.Entry(segment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SegmentExists(id))
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

        // POST: api/Segments
        [HttpPost]
        public async Task<ActionResult<Segment>> PostSegment(Segment segment)
        {
            _context.Segment.Add(segment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SegmentExists(segment.SegmentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSegment", new { id = segment.SegmentId }, segment);
        }

        // DELETE: api/Segments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Segment>> DeleteSegment(int id)
        {
            var segment = await _context.Segment.FindAsync(id);
            if (segment == null)
            {
                return NotFound();
            }

            _context.Segment.Remove(segment);
            await _context.SaveChangesAsync();

            return segment;
        }

        private bool SegmentExists(int id)
        {
            return _context.Segment.Any(e => e.SegmentId == id);
        }
    }
}
