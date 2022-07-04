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
    public class DishProductController : ControllerBase
    {
        private readonly DataContext _context;

        public DishProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishProduct>>> GetDishProducts()
        {
            return await _context.DishProducts.ToListAsync();
        }


        [HttpGet("getDishProduct")]
        public async Task<ActionResult<DishProduct>> GetDishProduct([FromQuery]int productId, [FromQuery] int dishId)
        {
            var dish = await _context.DishProducts.FirstOrDefaultAsync(x => x.ProductId == productId && x.DishId == dishId);

            if (dish == null)
            {
                return NotFound();
            }

            return dish;
        }


        [HttpPost]
        public async Task<ActionResult<DishProduct>> PostDishProduct(DishProduct dish)
        {
            _context.DishProducts.Add(dish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDishProduct", new { dishId = dish.DishId, productId = dish.ProductId }, dish);
        }

        [HttpPost("postDishProducts")]
        public async Task<ActionResult<DishProduct>> PostDishesProducts(List<DishProduct> dishProduct)
        {

            foreach (var item in dishProduct)
            {
                _context.DishProducts.Add(item);
                _context.SaveChanges();

                var queryProduct = (from dishProducts in _context.DishProducts
                                    join product in _context.Products on dishProducts.ProductId equals product.ProductId
                                    where dishProducts.DishId == item.DishId && dishProducts.ProductId == item.ProductId
                                    select product).FirstOrDefault();

                var queryDish = (from dishProducts in _context.DishProducts
                                       join dish in _context.Dishes on dishProducts.DishId equals dish.DishId
                                       where dishProducts.DishId == item.DishId && dishProducts.ProductId == item.ProductId
                                       select dish).FirstOrDefault();

                queryDish.DishPrice += queryProduct.ProductPrice;

                var queryMenu = (from dishes in _context.Dishes
                                 join foodMenuDishes in _context.FoodMenuDishes on dishes.DishId equals foodMenuDishes.DishId
                                 join foodMenu in _context.FoodMenus on foodMenuDishes.FoodMenuId equals foodMenu.FoodMenuId
                                 join menu in _context.Menus on foodMenu.FoodMenuId equals menu.FoodMenuId
                                 where dishes.DishId == item.DishId
                                 select menu).ToList();

                foreach (var menu in queryMenu)
                {
                    menu.MenuPrice += queryProduct.ProductPrice;
                }

                await _context.SaveChangesAsync();

            }

            return Ok();
        }
    }
}
