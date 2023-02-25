using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using airbnb.Models;

namespace airbnb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Place_ServiceController : ControllerBase
    {
        private readonly AirbnbDbContext _context;

        public Place_ServiceController(AirbnbDbContext context)
        {
            _context = context;
        }

        // GET: api/Place_Service
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place_Service>>> GetPlace_Service()
        {
            return await _context.Place_Service.ToListAsync();
        }

        // GET: api/Place_Service/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Place_Service>> GetPlace_Service(int id)
        {
            var place_Service = await _context.Place_Service.FindAsync(id);

            if (place_Service == null)
            {
                return NotFound();
            }

            return place_Service;
        }

        // PUT: api/Place_Service/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlace_Service(int id, Place_Service place_Service)
        {
            if (id != place_Service.PlaceId)
            {
                return BadRequest();
            }

            _context.Entry(place_Service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Place_ServiceExists(id))
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

        // POST: api/Place_Service
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Place_Service>> PostPlace_Service(Place_Service place_Service)
        {
            _context.Place_Service.Add(place_Service);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Place_ServiceExists(place_Service.PlaceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlace_Service", new { id = place_Service.PlaceId }, place_Service);
        }

        // DELETE: api/Place_Service/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlace_Service(int id)
        {
            var place_Service = await _context.Place_Service.FindAsync(id);
            if (place_Service == null)
            {
                return NotFound();
            }

            _context.Place_Service.Remove(place_Service);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Place_ServiceExists(int id)
        {
            return _context.Place_Service.Any(e => e.PlaceId == id);
        }
    }
}
