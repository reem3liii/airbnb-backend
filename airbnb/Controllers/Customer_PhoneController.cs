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
    public class Customer_PhoneController : ControllerBase
    {
        private readonly AirbnbDbContext _context;

        public Customer_PhoneController(AirbnbDbContext context)
        {
            _context = context;
        }

        // GET: api/Customer_Phone
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer_Phone>>> GetCustomer_Phone()
        {
            return await _context.Customer_Phone.ToListAsync();
        }

        // GET: api/Customer_Phone/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer_Phone>> GetCustomer_Phone(int id)
        {
            var customer_Phone = await _context.Customer_Phone.FindAsync(id);

            if (customer_Phone == null)
            {
                return NotFound();
            }

            return customer_Phone;
        }

        // PUT: api/Customer_Phone/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer_Phone(int id, Customer_Phone customer_Phone)
        {
            if (id != customer_Phone.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer_Phone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Customer_PhoneExists(id))
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

        // POST: api/Customer_Phone
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer_Phone>> PostCustomer_Phone(Customer_Phone customer_Phone)
        {
            _context.Customer_Phone.Add(customer_Phone);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Customer_PhoneExists(customer_Phone.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomer_Phone", new { id = customer_Phone.CustomerId }, customer_Phone);
        }

        // DELETE: api/Customer_Phone/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer_Phone(int id)
        {
            var customer_Phone = await _context.Customer_Phone.FindAsync(id);
            if (customer_Phone == null)
            {
                return NotFound();
            }

            _context.Customer_Phone.Remove(customer_Phone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Customer_PhoneExists(int id)
        {
            return _context.Customer_Phone.Any(e => e.CustomerId == id);
        }
    }
}
