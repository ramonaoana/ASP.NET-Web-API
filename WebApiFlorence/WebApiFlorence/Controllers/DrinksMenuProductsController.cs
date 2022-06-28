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
    public class DrinksMenuProductsController : ControllerBase
    {
        private readonly DataContext _context;
        private String URL = "https://localhost:7228/api/";

        public DrinksMenuProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrinksMenuProduct>>> GetDrinksMenuProducts()
        {
            return await _context.DrinksMenuProducts.ToListAsync();
        }


        [HttpGet("getDrinksMenuProduct")]
        public async Task<ActionResult<DrinksMenuProduct>> GetDrinksMenuProduct([FromQuery] int drinksMenuId, [FromQuery] int productId)
        {
            var drinksMenuProduct = await _context.DrinksMenuProducts.FirstOrDefaultAsync(x => x.DrinksMenuId == drinksMenuId && x.ProductId == productId);

            if (drinksMenuProduct == null)
            {
                return NotFound();
            }

            return drinksMenuProduct;
        }


        [HttpPost]
        public async Task<ActionResult<DishProduct>> PostDrinksMenuProduct(DrinksMenuProduct drinksMenuProduct)
        {
            _context.DrinksMenuProducts.Add(drinksMenuProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrinksMenuProduct", new { drinksMenuId = drinksMenuProduct.DrinksMenuId, productId = drinksMenuProduct.ProductId }, drinksMenuProduct);
        }

        [HttpPost("postDrinksMenusProducts")]
        public async Task<ActionResult<DrinksMenuProduct>> PostDishes(List<DrinksMenuProduct> drinksmenus)
        {

            foreach (var item in drinksmenus)
            {
                _context.DrinksMenuProducts.Add(item);
                _context.SaveChanges();


                var queryProduct = (from drinksMenuProducts in _context.DrinksMenuProducts
                                    join product in _context.Products on drinksMenuProducts.ProductId equals product.ProductId
                                    where drinksMenuProducts.DrinksMenuId == item.DrinksMenuId && drinksMenuProducts.ProductId == item.ProductId
                                    select product).FirstOrDefault();

                var queryDrinksMenu = (from drinksMenuProducts in _context.DrinksMenuProducts
                                    join drinksMenu in _context.DrinksMenus on drinksMenuProducts.DrinksMenuId equals drinksMenu.DrinksMenuId
                                    where drinksMenuProducts.DrinksMenuId == item.DrinksMenuId && drinksMenuProducts.ProductId == item.ProductId
                                    select drinksMenu).FirstOrDefault();

                queryDrinksMenu.DrinksMenuPrice += queryProduct.ProductPrice;

                await _context.SaveChangesAsync();

            }

            return Ok();
        }

    }
}
