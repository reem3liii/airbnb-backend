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
    public class Owner_PhoneController : ControllerBase
    {
        private readonly AirbnbDbContext _context;

        public Owner_PhoneController(AirbnbDbContext context)
        {
            _context = context;
        }

        // GET: api/Owner_Phone
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owner_Phone>>> GetOwner_Phone()
        {
            return await _context.Owner_Phone.ToListAsync();
        }

        // GET: api/Owner_Phone/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner_Phone>> GetOwner_Phone(int id)
        {
            var owner_Phone = await _context.Owner_Phone.FindAsync(id);

            if (owner_Phone == null)
            {
                return NotFound();
            }

            return owner_Phone;
        }

        // PUT: api/Owner_Phone/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner_Phone(int id, Owner_Phone owner_Phone)
        {
            if (id != owner_Phone.OwnerId)
            {
                return BadRequest();
            }

            _context.Entry(owner_Phone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Owner_PhoneExists(id))
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

        // POST: api/Owner_Phone
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Owner_Phone>> PostOwner_Phone(Owner_Phone owner_Phone)
        {
            _context.Owner_Phone.Add(owner_Phone);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Owner_PhoneExists(owner_Phone.OwnerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOwner_Phone", new { id = owner_Phone.OwnerId }, owner_Phone);
        }

        // DELETE: api/Owner_Phone/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner_Phone(int id)
        {
            var owner_Phone = await _context.Owner_Phone.FindAsync(id);
            if (owner_Phone == null)
            {
                return NotFound();
            }

            _context.Owner_Phone.Remove(owner_Phone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Owner_PhoneExists(int id)
        {
            return _context.Owner_Phone.Any(e => e.OwnerId == id);
        }
    }
}
