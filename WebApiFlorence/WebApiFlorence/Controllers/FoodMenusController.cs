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
    public class FoodMenusController : ControllerBase
    {
        private readonly DataContext _context;

        public FoodMenusController(DataContext context)
        {
            _context = context;
        }


        // GET: api/FoodMenus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodMenu>> GetFoodMenu(int id)
        {
            var foodMenu = await _context.FoodMenus.FindAsync(id);

            if (foodMenu == null)
            {
                return NotFound();
            }

            return foodMenu;
        }

        //[HttpGet("getFirstDishFromMenu")]
        //public IActionResult GetFirstDishFromFoodMenu([FromQuery] int id)
        //{
        //    var result = (from foodmenu in _context.FoodMenus
        //                  join firstDish in _context.FirstDish
        //                  on foodmenu.FirstDishId equals firstDish.FirstDishId
        //                  where foodmenu.FoodMenuId == id
        //                  select new
        //                  {
        //                      firstDishName = firstDish.FirstDishName,
        //                      firstDishDescription = firstDish.FirstDishDescription,
        //                      firstDishPictureData = firstDish.FirstDishPictureData
        //                  }).FirstOrDefault();
        //    return Ok(result);
        //}

        //[HttpGet("getFoodMenusNames/{type}")]
        //public IActionResult GetFoodMenusNames(int type)
        //{
        //    var result = (from foodmenu in _context.FoodMenus
        //                  where foodmenu.FoodMenuTypeEvent == type
        //                  select new
        //                  {
        //                      foodMenuName = foodmenu.FoodMenuName
        //                  }).ToList();
        //    return Ok(result);
        //}


        //[HttpGet("getMenusByType/{id}")]
        //public IActionResult GetFullFoodMenu(int id)
        //{
        //    var result = (from foodmenu in _context.FoodMenus
        //                  join firstDish in _context.FirstDish on foodmenu.FirstDishId equals firstDish.FirstDishId
        //                  join secondDish in _context.SecondDish on foodmenu.SecondDishId equals secondDish.SecondDishId
        //                  join thirdDish in _context.ThirdDish on foodmenu.ThirdDishId equals thirdDish.ThirdDishId
        //                  join fourthDish in _context.FourthDish on foodmenu.FourthDishId equals fourthDish.FourthDishId
        //                  where foodmenu.FoodMenuTypeEvent == id
        //                  select new
        //                  {
        //                      foodMenuName = foodmenu.FoodMenuName,
        //                      foodMenuPrice = foodmenu.FoodMenuPrice,
        //                      foodMenuDescription = foodmenu.FoodMenuDescription,

        //                      firstDishName = firstDish.FirstDishName,
        //                      firstDishDescription = firstDish.FirstDishDescription,
        //                      firstDishPictureData = firstDish.FirstDishPictureData,

        //                      secondDishName = secondDish.SecondDishName,
        //                      secondDishDescription = secondDish.SecondDishDescription,
        //                      secondDishPictureData = secondDish.SecondDishPictureData,

        //                      thirdDishName = thirdDish.ThirdDishName,
        //                      thirdDishDescription = thirdDish.ThirdDishDescription,
        //                      thirdDishPictureData = thirdDish.ThirdDishPictureData,

        //                      fourthDishName = fourthDish.FourthDishName,
        //                      fourthDishDescription = fourthDish.FourthDishDescription,
        //                      fourthDishPictureData = fourthDish.FourthDishPictureData

        //                  }).ToList();
        //    return Ok(result);
        //}

        //[HttpGet("getMenuByName/{name}")]
        //public IActionResult GetFoodMenuByName(String name)
        //{
        //    var result = (from foodmenu in _context.FoodMenus
        //                  join firstDish in _context.FirstDish on foodmenu.FirstDishId equals firstDish.FirstDishId
        //                  join secondDish in _context.SecondDish on foodmenu.SecondDishId equals secondDish.SecondDishId
        //                  join thirdDish in _context.ThirdDish on foodmenu.ThirdDishId equals thirdDish.ThirdDishId
        //                  join fourthDish in _context.FourthDish on foodmenu.FourthDishId equals fourthDish.FourthDishId
        //                  where foodmenu.FoodMenuName == name
        //                  select new
        //                  {
        //                      foodMenuName = foodmenu.FoodMenuName,
        //                      foodMenuPrice = foodmenu.FoodMenuPrice,
        //                      foodMenuDescription = foodmenu.FoodMenuDescription,

        //                      firstDishName = firstDish.FirstDishName,
        //                      firstDishDescription = firstDish.FirstDishDescription,
        //                      firstDishPictureData = firstDish.FirstDishPictureData,

        //                      secondDishName = secondDish.SecondDishName,
        //                      secondDishDescription = secondDish.SecondDishDescription,
        //                      secondDishPictureData = secondDish.SecondDishPictureData,

        //                      thirdDishName = thirdDish.ThirdDishName,
        //                      thirdDishDescription = thirdDish.ThirdDishDescription,
        //                      thirdDishPictureData = thirdDish.ThirdDishPictureData,

        //                      fourthDishName = fourthDish.FourthDishName,
        //                      fourthDishDescription = fourthDish.FourthDishDescription,
        //                      fourthDishPictureData = fourthDish.FourthDishPictureData

        //                  }).FirstOrDefault();
        //    return Ok(result);
        //}



        // GET: api/FoodMenus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodMenu>>> GetFoodMenus()
        {
            return await _context.FoodMenus.ToListAsync();
        }

        // PUT: api/FoodMenus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodMenu(int id, FoodMenu foodMenu)
        {
            if (id != foodMenu.FoodMenuId)
            {
                return BadRequest();
            }

            _context.Entry(foodMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodMenuExists(id))
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

        // POST: api/FoodMenus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodMenu>> PostFoodMenu(FoodMenu foodMenu)
        {
            _context.FoodMenus.Add(foodMenu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodMenu", new { id = foodMenu.FoodMenuId }, foodMenu);
        }

        [HttpPost("postFoodMenus")]
        public async Task<ActionResult<FoodMenu>>  PostFoodMenus(List<FoodMenu> foodMenus)
        {
            foreach (var item in foodMenus)
            {
                _context.FoodMenus.Add(item);
                _context.SaveChanges();

                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        // DELETE: api/FoodMenus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodMenu(int id)
        {
            var foodMenu = await _context.FoodMenus.FindAsync(id);
            if (foodMenu == null)
            {
                return NotFound();
            }

            _context.FoodMenus.Remove(foodMenu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodMenuExists(int id)
        {
            return _context.FoodMenus.Any(e => e.FoodMenuId == id);
        }
    }
}
