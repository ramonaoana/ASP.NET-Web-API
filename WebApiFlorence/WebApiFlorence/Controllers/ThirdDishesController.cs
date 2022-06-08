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
    public class ThirdDishesController : ControllerBase
    {
        private readonly DataContext _context;

        public ThirdDishesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ThirdDishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThirdDish>>> GetThirdDish()
        {
            return await _context.ThirdDish.ToListAsync();
        }

        // GET: api/ThirdDishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThirdDish>> GetThirdDish(int id)
        {
            var thirdDish = await _context.ThirdDish.FindAsync(id);

            if (thirdDish == null)
            {
                return NotFound();
            }

            return thirdDish;
        }

        // PUT: api/ThirdDishes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThirdDish(int id, ThirdDish thirdDish)
        {
            if (id != thirdDish.ThirdDishId)
            {
                return BadRequest();
            }

            _context.Entry(thirdDish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThirdDishExists(id))
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

        // POST: api/ThirdDishes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThirdDish>> PostThirdDish(ThirdDish thirdDish)
        {
            _context.ThirdDish.Add(thirdDish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThirdDish", new { id = thirdDish.ThirdDishId }, thirdDish);
        }

        // DELETE: api/ThirdDishes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThirdDish(int id)
        {
            var thirdDish = await _context.ThirdDish.FindAsync(id);
            if (thirdDish == null)
            {
                return NotFound();
            }

            _context.ThirdDish.Remove(thirdDish);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThirdDishExists(int id)
        {
            return _context.ThirdDish.Any(e => e.ThirdDishId == id);
        }
    }
}
