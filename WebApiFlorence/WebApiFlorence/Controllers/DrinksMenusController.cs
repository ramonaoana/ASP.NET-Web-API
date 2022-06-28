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
    public class DrinksMenusController : ControllerBase
    {
        private readonly DataContext _context;

        public DrinksMenusController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DrinksMenus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrinksMenu>>> GetDrinksMenus()
        {
            return await _context.DrinksMenus.ToListAsync();
        }

        // GET: api/DrinksMenus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DrinksMenu>> GetDrinksMenu(int id)
        {
            var drinksMenu = await _context.DrinksMenus.FindAsync(id);

            if (drinksMenu == null)
            {
                return NotFound();
            }

            return drinksMenu;
        }

        // PUT: api/DrinksMenus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrinksMenu(int id, DrinksMenu drinksMenu)
        {
            if (id != drinksMenu.DrinksMenuId)
            {
                return BadRequest();
            }

            _context.Entry(drinksMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinksMenuExists(id))
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

        // POST: api/DrinksMenus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DrinksMenu>> PostDrinksMenu(DrinksMenu drinksMenu)
        {
            _context.DrinksMenus.Add(drinksMenu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrinksMenu", new { id = drinksMenu.DrinksMenuId }, drinksMenu);
        }

        [HttpPost("postDrinksMenus")]
        public async Task<ActionResult<DrinksMenu>> PostDishes(List<DrinksMenu> drinksmenus)
        {

            foreach (var item in drinksmenus)
            {
                _context.DrinksMenus.Add(item);
            }
            await _context.SaveChangesAsync();

            return Ok();
        }


        // DELETE: api/DrinksMenus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrinksMenu(int id)
        {
            var drinksMenu = await _context.DrinksMenus.FindAsync(id);
            if (drinksMenu == null)
            {
                return NotFound();
            }

            _context.DrinksMenus.Remove(drinksMenu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrinksMenuExists(int id)
        {
            return _context.DrinksMenus.Any(e => e.DrinksMenuId == id);
        }
    }
}
