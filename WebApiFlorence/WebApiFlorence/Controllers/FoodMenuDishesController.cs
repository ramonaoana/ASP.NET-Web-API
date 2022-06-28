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
    public class FoodMenuDishesController : ControllerBase
    {
        private readonly DataContext _context;

        public FoodMenuDishesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodMenuDish>>> GetFoodMenuDishes()
        {
            return await _context.FoodMenuDishes.ToListAsync();
        }


        [HttpGet("getFoodMenuDish")]
        public async Task<ActionResult<FoodMenuDish>> GetFoodMenuDish([FromQuery] int foodMenuId, [FromQuery] int dishId)
        {
            var dish = await _context.FoodMenuDishes.FirstOrDefaultAsync(x => x.FoodMenuId == foodMenuId && x.DishId == dishId);

            if (dish == null)
            {
                return NotFound();
            }

            return dish;
        }

        [HttpPost]
        public async Task<ActionResult<FoodMenuDish>> PostFoodMenuDish(FoodMenuDish dish)
        {
            _context.FoodMenuDishes.Add(dish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodMenuDish", new { foodMenuId = dish.FoodMenuId, dishId=dish.FoodMenuId}, dish);
        }


        [HttpPost("postFoodMenusDishes")]
        public async Task<ActionResult<FoodMenuDish>> PostDishes(List<FoodMenuDish> foodMenuDishes)
        {

            foreach (var item in foodMenuDishes)
            {
                _context.FoodMenuDishes.Add(item);
                _context.SaveChanges();


                var queryDish = (from foodMenusDishes in _context.FoodMenuDishes
                                    join dish in _context.Dishes on foodMenusDishes.DishId equals dish.DishId
                                    where foodMenusDishes.DishId == item.DishId && foodMenusDishes.FoodMenuId == item.FoodMenuId
                                    select dish).FirstOrDefault();

                var queryFoodMenu= (from foodMenusDishes in _context.FoodMenuDishes
                                      join foodMenus in _context.FoodMenus on foodMenusDishes.FoodMenuId equals foodMenus.FoodMenuId
                                    where foodMenusDishes.DishId == item.DishId && foodMenusDishes.FoodMenuId == item.FoodMenuId
                                    select foodMenus).FirstOrDefault();

                queryFoodMenu.FoodMenuPrice += queryDish.DishPrice;

                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
