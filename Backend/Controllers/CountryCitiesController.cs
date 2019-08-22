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
    public class CountryCitiesController : ControllerBase
    {
        private readonly ProcesoLogisticoContext _context;

        public CountryCitiesController(ProcesoLogisticoContext context)
        {
            _context = context;
        }

        // GET: api/CountryCities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryCity>>> GetCountryCity()
        {
            return await _context.CountryCity.ToListAsync();
        }

        // GET: api/CountryCities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryCity>> GetCountryCity(int id)
        {
            var countryCity = await _context.CountryCity.FindAsync(id);

            if (countryCity == null)
            {
                return NotFound();
            }

            return countryCity;
        }

        // PUT: api/CountryCities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountryCity(int id, CountryCity countryCity)
        {
            if (id != countryCity.CountryId)
            {
                return BadRequest();
            }

            _context.Entry(countryCity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryCityExists(id))
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

        // POST: api/CountryCities
        [HttpPost]
        public async Task<ActionResult<CountryCity>> PostCountryCity(CountryCity countryCity)
        {
            _context.CountryCity.Add(countryCity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CountryCityExists(countryCity.CountryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCountryCity", new { id = countryCity.CountryId }, countryCity);
        }

        // DELETE: api/CountryCities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CountryCity>> DeleteCountryCity(int id)
        {
            var countryCity = await _context.CountryCity.FindAsync(id);
            if (countryCity == null)
            {
                return NotFound();
            }

            _context.CountryCity.Remove(countryCity);
            await _context.SaveChangesAsync();

            return countryCity;
        }

        private bool CountryCityExists(int id)
        {
            return _context.CountryCity.Any(e => e.CountryId == id);
        }
    }
}
