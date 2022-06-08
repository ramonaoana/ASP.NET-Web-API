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
    public class FirstDishesController : ControllerBase
    {
        private readonly DataContext _context;

        public FirstDishesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FirstDishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FirstDish>>> GetFirstDish()
        {
            return await _context.FirstDish.ToListAsync();
        }

        // GET: api/FirstDishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FirstDish>> GetFirstDish(int id)
        {
            var firstDish = await _context.FirstDish.FindAsync(id);

            if (firstDish == null)
            {
                return NotFound();
            }

            return firstDish;
        }

        // PUT: api/FirstDishes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFirstDish(int id, FirstDish firstDish)
        {
            if (id != firstDish.FirstDishId)
            {
                return BadRequest();
            }

            _context.Entry(firstDish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirstDishExists(id))
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

        // POST: api/FirstDishes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FirstDish>> PostFirstDish(FirstDish firstDish)
        {
            _context.FirstDish.Add(firstDish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFirstDish", new { id = firstDish.FirstDishId }, firstDish);
        }

        // DELETE: api/FirstDishes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFirstDish(int id)
        {
            var firstDish = await _context.FirstDish.FindAsync(id);
            if (firstDish == null)
            {
                return NotFound();
            }

            _context.FirstDish.Remove(firstDish);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FirstDishExists(int id)
        {
            return _context.FirstDish.Any(e => e.FirstDishId == id);
        }
    }
}
