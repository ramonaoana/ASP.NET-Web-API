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
    public class FourthDishesController : ControllerBase
    {
        private readonly DataContext _context;

        public FourthDishesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FourthDishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FourthDish>>> GetFourthDish()
        {
            return await _context.FourthDish.ToListAsync();
        }

        // GET: api/FourthDishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FourthDish>> GetFourthDish(int id)
        {
            var fourthDish = await _context.FourthDish.FindAsync(id);

            if (fourthDish == null)
            {
                return NotFound();
            }

            return fourthDish;
        }

        // PUT: api/FourthDishes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFourthDish(int id, FourthDish fourthDish)
        {
            if (id != fourthDish.FourthDishId)
            {
                return BadRequest();
            }

            _context.Entry(fourthDish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FourthDishExists(id))
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

        // POST: api/FourthDishes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FourthDish>> PostFourthDish(FourthDish fourthDish)
        {
            _context.FourthDish.Add(fourthDish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFourthDish", new { id = fourthDish.FourthDishId }, fourthDish);
        }

        // DELETE: api/FourthDishes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFourthDish(int id)
        {
            var fourthDish = await _context.FourthDish.FindAsync(id);
            if (fourthDish == null)
            {
                return NotFound();
            }

            _context.FourthDish.Remove(fourthDish);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FourthDishExists(int id)
        {
            return _context.FourthDish.Any(e => e.FourthDishId == id);
        }
    }
}
