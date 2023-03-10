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
    public class MemberController : ControllerBase
    {
        private readonly DataContext _context;

        public MemberController(DataContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetMembers()
        {
            return await _context.Restaurants.ToListAsync();
        }

        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetMember(int id)
        {
            var member = await _context.Restaurants.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        // GET
        [HttpGet("getByType/{type}")]
        public async Task<ActionResult<Restaurant>> GetMemberByType(int type)
        {
            var member = await _context.Restaurants.FirstOrDefaultAsync(x => x.RestaurantType == type);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, Restaurant member)
        {
            if (id != member.RestaurantId)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
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
        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostMember(Restaurant member)
        {
            _context.Restaurants.Add(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMember", new { id = member.RestaurantId }, member);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _context.Restaurants.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Restaurants.Remove(member);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MemberExists(int id)
        {
            return _context.Restaurants.Any(e => e.RestaurantId == id);
        }
    }
}
