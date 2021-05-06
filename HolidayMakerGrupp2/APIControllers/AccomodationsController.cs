using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HolidayMakerGrupp2.Models.Database;

namespace HolidayMakerGrupp2.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccomodationsController : ControllerBase
    {
        private readonly HolidayMakerGrupp2Context _context;

        public AccomodationsController(HolidayMakerGrupp2Context context)
        {
            _context = context;
        }

        // GET: api/Accomodations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accomodation>>> GetAccomodations()
        {
            return await _context.Accomodations.ToListAsync();
        }

        // GET: api/Accomodations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accomodation>> GetAccomodation(int id)
        {
            var accomodation = await _context.Accomodations.FindAsync(id);

            if (accomodation == null)
            {
                return NotFound();
            }

            return accomodation;
        }

        // PUT: api/Accomodations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccomodation(int id, Accomodation accomodation)
        {
            if (id != accomodation.Id)
            {
                return BadRequest();
            }

            _context.Entry(accomodation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccomodationExists(id))
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

        // POST: api/Accomodations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Accomodation>> PostAccomodation(Accomodation accomodation)
        {
            _context.Accomodations.Add(accomodation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccomodation", new { id = accomodation.Id }, accomodation);
        }

        // DELETE: api/Accomodations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccomodation(int id)
        {
            var accomodation = await _context.Accomodations.FindAsync(id);
            if (accomodation == null)
            {
                return NotFound();
            }

            _context.Accomodations.Remove(accomodation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccomodationExists(int id)
        {
            return _context.Accomodations.Any(e => e.Id == id);
        }
    }
}
