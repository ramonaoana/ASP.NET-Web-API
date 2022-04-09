#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiFlorence.Classes;
using WebApiFlorence.Data;

namespace WebApiFlorence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly DataContext _context;

        public SpecialOffersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SpecialOffers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialOffer>>> GetSpecialOffers()
        {
            return await _context.SpecialOffers.ToListAsync();
        }

        // GET: api/SpecialOffers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialOffer>> GetSpecialOffer(int id)
        {
            var specialOffer = await _context.SpecialOffers.FindAsync(id);

            if (specialOffer == null)
            {
                return NotFound();
            }

            return specialOffer;
        }

        // PUT: api/SpecialOffers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialOffer(int id, SpecialOffer specialOffer)
        {
            if (id != specialOffer.Id)
            {
                return BadRequest();
            }

            _context.Entry(specialOffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialOfferExists(id))
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

        // POST: api/SpecialOffers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SpecialOffer>> PostSpecialOffer(SpecialOffer specialOffer)
        {
            _context.SpecialOffers.Add(specialOffer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecialOffer", new { id = specialOffer.Id }, specialOffer);
        }

        // DELETE: api/SpecialOffers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(int id)
        {
            var specialOffer = await _context.SpecialOffers.FindAsync(id);
            if (specialOffer == null)
            {
                return NotFound();
            }

            _context.SpecialOffers.Remove(specialOffer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpecialOfferExists(int id)
        {
            return _context.SpecialOffers.Any(e => e.Id == id);
        }
    }
}
