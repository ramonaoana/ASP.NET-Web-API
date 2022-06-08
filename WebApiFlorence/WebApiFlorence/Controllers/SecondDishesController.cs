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
    public class SecondDishesController : ControllerBase
    {
        private readonly DataContext _context;

        public SecondDishesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SecondDishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SecondDish>>> GetSecondDish()
        {
            return await _context.SecondDish.ToListAsync();
        }

        // GET: api/SecondDishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SecondDish>> GetSecondDish(int id)
        {
            var secondDish = await _context.SecondDish.FindAsync(id);

            if (secondDish == null)
            {
                return NotFound();
            }

            return secondDish;
        }

        // PUT: api/SecondDishes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSecondDish(int id, SecondDish secondDish)
        {
            if (id != secondDish.SecondDishId)
            {
                return BadRequest();
            }

            _context.Entry(secondDish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecondDishExists(id))
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

        // POST: api/SecondDishes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SecondDish>> PostSecondDish(SecondDish secondDish)
        {
            _context.SecondDish.Add(secondDish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSecondDish", new { id = secondDish.SecondDishId }, secondDish);
        }

        // DELETE: api/SecondDishes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSecondDish(int id)
        {
            var secondDish = await _context.SecondDish.FindAsync(id);
            if (secondDish == null)
            {
                return NotFound();
            }

            _context.SecondDish.Remove(secondDish);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SecondDishExists(int id)
        {
            return _context.SecondDish.Any(e => e.SecondDishId == id);
        }
    }
}
