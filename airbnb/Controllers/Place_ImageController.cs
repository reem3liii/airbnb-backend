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
    public class Place_ImageController : ControllerBase
    {
        private readonly AirbnbDbContext _context;

        public Place_ImageController(AirbnbDbContext context)
        {
            _context = context;
        }

        // GET: api/Place_Image
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place_Image>>> GetPlace_Image()
        {
            return await _context.Place_Image.ToListAsync();
        }

        // GET: api/Place_Image/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Place_Image>> GetPlace_Image(int id)
        {
            var place_Image = await _context.Place_Image.FindAsync(id);

            if (place_Image == null)
            {
                return NotFound();
            }

            return place_Image;
        }

        // PUT: api/Place_Image/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlace_Image(int id, Place_Image place_Image)
        {
            if (id != place_Image.PlaceId)
            {
                return BadRequest();
            }

            _context.Entry(place_Image).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Place_ImageExists(id))
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

        // POST: api/Place_Image
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Place_Image>> PostPlace_Image(Place_Image place_Image)
        {
            _context.Place_Image.Add(place_Image);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Place_ImageExists(place_Image.PlaceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlace_Image", new { id = place_Image.PlaceId }, place_Image);
        }

        // DELETE: api/Place_Image/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlace_Image(int id)
        {
            var place_Image = await _context.Place_Image.FindAsync(id);
            if (place_Image == null)
            {
                return NotFound();
            }

            _context.Place_Image.Remove(place_Image);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Place_ImageExists(int id)
        {
            return _context.Place_Image.Any(e => e.PlaceId == id);
        }
    }
}
