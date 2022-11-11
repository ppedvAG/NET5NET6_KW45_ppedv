using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeoRelationalSample.Data;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesInCountriesController : ControllerBase
    {
        private readonly GeoDbContext _context;

        public LanguagesInCountriesController(GeoDbContext context)
        {
            _context = context;
        }

        // GET: api/LanguagesInCountries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguagesInCountry>>> GetLanguagesInCountries()
        {
            return await _context.LanguagesInCountries.ToListAsync();
        }

        // GET: api/LanguagesInCountries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LanguagesInCountry>> GetLanguagesInCountry(int id)
        {
            var languagesInCountry = await _context.LanguagesInCountries.FindAsync(id);

            if (languagesInCountry == null)
            {
                return NotFound();
            }

            return languagesInCountry;
        }

        // PUT: api/LanguagesInCountries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguagesInCountry(int id, LanguagesInCountry languagesInCountry)
        {
            if (id != languagesInCountry.Id)
            {
                return BadRequest();
            }

            _context.Entry(languagesInCountry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguagesInCountryExists(id))
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

        // POST: api/LanguagesInCountries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LanguagesInCountry>> PostLanguagesInCountry(LanguagesInCountry languagesInCountry)
        {
            _context.LanguagesInCountries.Add(languagesInCountry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLanguagesInCountry", new { id = languagesInCountry.Id }, languagesInCountry);
        }

        // DELETE: api/LanguagesInCountries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguagesInCountry(int id)
        {
            var languagesInCountry = await _context.LanguagesInCountries.FindAsync(id);
            if (languagesInCountry == null)
            {
                return NotFound();
            }

            _context.LanguagesInCountries.Remove(languagesInCountry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LanguagesInCountryExists(int id)
        {
            return _context.LanguagesInCountries.Any(e => e.Id == id);
        }
    }
}
