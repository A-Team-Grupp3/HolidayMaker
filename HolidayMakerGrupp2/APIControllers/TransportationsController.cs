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
    public class TransportationsController : ControllerBase
    {
        private readonly HolidayMakerGrupp2Context _context;

        public TransportationsController(HolidayMakerGrupp2Context context)
        {
            _context = context;
        }

        // GET: api/Transportations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transportation>>> GetTransportations()
        {
            return await _context.Transportations.ToListAsync();
        }

        // GET: api/Transportations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transportation>> GetTransportation(int id)
        {
            var transportation = await _context.Transportations.FindAsync(id);

            if (transportation == null)
            {
                return NotFound();
            }

            return transportation;
        }

        // PUT: api/Transportations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransportation(int id, Transportation transportation)
        {
            if (id != transportation.Id)
            {
                return BadRequest();
            }

            _context.Entry(transportation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportationExists(id))
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

        // POST: api/Transportations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transportation>> PostTransportation(Transportation transportation)
        {
            _context.Transportations.Add(transportation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransportation", new { id = transportation.Id }, transportation);
        }

        // DELETE: api/Transportations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransportation(int id)
        {
            var transportation = await _context.Transportations.FindAsync(id);
            if (transportation == null)
            {
                return NotFound();
            }

            _context.Transportations.Remove(transportation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransportationExists(int id)
        {
            return _context.Transportations.Any(e => e.Id == id);
        }
    }
}
