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
    public class MenusController : ControllerBase
    {
        private readonly DataContext _context;

        public MenusController(DataContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {
            return await _context.Menus.ToListAsync();
        }

        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);

            if (menu == null)
            {
                return NotFound();
            }

            return menu;
        }

        [HttpGet("getMenusNames/{type}")]
        public IActionResult GetMenusNames(int type)
        {
            var result = (from menu in _context.Menus
                          where menu.MenuTypeEvent == type
                          select new
                          {
                              menuName = menu.MenuName
                          }).ToList();
            return Ok(result);
        }


        [HttpGet("getMenuPrice/{name}")]
        public IActionResult GetMenuPrice(String name)
        {
            var result = (from menu in _context.Menus
                          where menu.MenuName == name
                          select new
                          {
                              menuPrice = menu.MenuPrice,
                              menuId=menu.MenuId
                          }).FirstOrDefault();
            return Ok(result);
        }

        [HttpGet("getFoodMenusWithDetails/{name}")]
        public MenuDetails GetFoodMenuFromMenus(string name)
        {
            MenuDetails foodMenuDetails=new MenuDetails();

            var queryFoodMenu = (from menu in _context.Menus
                                 join foodMenu in _context.FoodMenus on menu.FoodMenuId equals foodMenu.FoodMenuId
                                 where menu.MenuName == name
                                 select new
                                 {
                                     foodMenu = foodMenu,
                                     menuDetails=menu
                                 }).FirstOrDefault();
            foodMenuDetails.Menu = queryFoodMenu.menuDetails;
            foodMenuDetails.FoodMenu = queryFoodMenu.foodMenu;

            var queryDishes = (from foodMenu in _context.FoodMenus
                             join foodMenuDishes in _context.FoodMenuDishes on foodMenu.FoodMenuId equals foodMenuDishes.FoodMenuId
                             join dishes in _context.Dishes on foodMenuDishes.DishId equals dishes.DishId
                             where foodMenu.FoodMenuId == queryFoodMenu.foodMenu.FoodMenuId
                             select dishes).ToList();

            List<DishDetails> list = new List<DishDetails>();
            foreach(Dish d in queryDishes)
            {
                DishDetails dishDetails = new DishDetails();
                dishDetails.dish = d;

                var queryProductsList = (from dish in _context.Dishes
                                         join dishesProducts in _context.DishProducts on dish.DishId equals dishesProducts.DishId
                                         join products in _context.Products on dishesProducts.ProductId equals products.ProductId
                                         where dish.DishId == d.DishId
                                         select products).ToList();
                dishDetails.productsList = queryProductsList;
                list.Add(dishDetails);
            }
            foodMenuDetails.Dishes = list;
            return foodMenuDetails;
        }

        [HttpGet("getMenuWithDetails/{name}")]
        public MenuDetails GetMenuByName(string name)
        {
            MenuDetails menuDetails = new MenuDetails();

            var queryFoodMenu = (from menu in _context.Menus
                                 join foodMenu in _context.FoodMenus on menu.FoodMenuId equals foodMenu.FoodMenuId
                                 where menu.MenuName == name
                                 select new
                                 {
                                     foodMenu = foodMenu,
                                     menuDetails = menu
                                 }).FirstOrDefault();

            var queryDrinksMenu = (from menu in _context.Menus
                                 join drinksMenu in _context.DrinksMenus on menu.DrinksMenuId equals drinksMenu.DrinksMenuId
                                 where menu.MenuName == name
                                 select new
                                 {
                                     drinksMenuDetails = drinksMenu
                                 }).FirstOrDefault();

            menuDetails.Menu = queryFoodMenu.menuDetails;
            menuDetails.DrinksMenu = queryDrinksMenu.drinksMenuDetails;
            menuDetails.FoodMenu = queryFoodMenu.foodMenu;

            var queryDishes = (from foodMenu in _context.FoodMenus
                               join foodMenuDishes in _context.FoodMenuDishes on foodMenu.FoodMenuId equals foodMenuDishes.FoodMenuId
                               join dishes in _context.Dishes on foodMenuDishes.DishId equals dishes.DishId
                               where foodMenu.FoodMenuId == queryFoodMenu.foodMenu.FoodMenuId
                               select dishes).ToList();

            var queryDrinks = (from drinksMenu in _context.DrinksMenus
                               join drinksProducts in _context.DrinksMenuProducts on drinksMenu.DrinksMenuId equals drinksProducts.DrinksMenuId
                               join products in _context.Products on drinksProducts.ProductId equals products.ProductId
                               where drinksMenu.DrinksMenuId == queryDrinksMenu.drinksMenuDetails.DrinksMenuId
                               select products).ToList();

            menuDetails.Drinks = queryDrinks;

            List<DishDetails> list = new List<DishDetails>();
            foreach (Dish d in queryDishes)
            {
                DishDetails dishDetails = new DishDetails();
                dishDetails.dish = d;

                var queryProductsList = (from dish in _context.Dishes
                                         join dishesProducts in _context.DishProducts on dish.DishId equals dishesProducts.DishId
                                         join products in _context.Products on dishesProducts.ProductId equals products.ProductId
                                         where dish.DishId == d.DishId
                                         select products).ToList();
                dishDetails.productsList = queryProductsList;
                list.Add(dishDetails);
            }
            menuDetails.Dishes = list;
            return menuDetails;
        }

        [HttpGet("getMenusWithDetails/{type}")]
        public List<MenuDetails> GetMenusByType(int type)
        {
            List<MenuDetails> menusDetails = new List<MenuDetails>();

            var query = (from menu in _context.Menus
                                join foodMenu in _context.FoodMenus on menu.FoodMenuId equals foodMenu.FoodMenuId
                                join drinksMenu in _context.DrinksMenus on menu.DrinksMenuId equals drinksMenu.DrinksMenuId
                                 where menu.MenuTypeEvent == type
                                 select new
                                 {
                                     foodMenu = foodMenu,
                                     menuDetails = menu,
                                     menuDrinks=drinksMenu
                                 }).ToList();

            foreach (var item in query)
            {
                MenuDetails menuDetails = new MenuDetails();
                menuDetails.FoodMenu = item.foodMenu;
                menuDetails.DrinksMenu = item.menuDrinks;
                menuDetails.Menu = item.menuDetails;

                var queryDishes = (from foodMenu in _context.FoodMenus
                                   join foodMenuDishes in _context.FoodMenuDishes on foodMenu.FoodMenuId equals foodMenuDishes.FoodMenuId
                                   join dishes in _context.Dishes on foodMenuDishes.DishId equals dishes.DishId
                                   where foodMenu.FoodMenuId == item.foodMenu.FoodMenuId
                                   select dishes).ToList();

                var queryDrinks = (from drinksMenu in _context.DrinksMenus
                                   join drinksProducts in _context.DrinksMenuProducts on drinksMenu.DrinksMenuId equals drinksProducts.DrinksMenuId
                                   join products in _context.Products on drinksProducts.ProductId equals products.ProductId
                                   where drinksMenu.DrinksMenuId == item.menuDrinks.DrinksMenuId
                                   select products).ToList();

                menuDetails.Drinks = queryDrinks;

                List<DishDetails> listOfDishDetails = new List<DishDetails>();
                foreach (Dish d in queryDishes)
                {
                    DishDetails dishDetails = new DishDetails();
                    dishDetails.dish = d;

                    var queryProductsList = (from dish in _context.Dishes
                                             join dishesProducts in _context.DishProducts on dish.DishId equals dishesProducts.DishId
                                             join products in _context.Products on dishesProducts.ProductId equals products.ProductId
                                             where dish.DishId == d.DishId
                                             select products).ToList();
                    dishDetails.productsList = queryProductsList;
                    listOfDishDetails.Add(dishDetails);
                }

                menuDetails.Dishes = listOfDishDetails;

                menusDetails.Add(menuDetails);
            }
            return menusDetails;

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu(int id, Menu menu)
        {
            if (id != menu.MenuId)
            {
                return BadRequest();
            }

            _context.Entry(menu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(id))
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
        [HttpPost("postMenus")]
        public async Task<ActionResult<Menu>> PostMenu(List<Menu> listOfMenus)
        {
            foreach (var menu in listOfMenus)
            {
                _context.Menus.Add(menu);
                _context.SaveChanges();

                var queryFoodMenu = (from menus in _context.Menus
                                     join foodMenu in _context.FoodMenus on menus.FoodMenuId equals foodMenu.FoodMenuId
                                     where menus.MenuId == menu.MenuId
                                     select foodMenu).FirstOrDefault();

                var queryDrinksMenu = (from menus in _context.Menus
                                       join drinksmenu in _context.DrinksMenus on menus.DrinksMenuId equals drinksmenu.DrinksMenuId
                                       where menus.MenuId == menu.MenuId
                                       select drinksmenu).FirstOrDefault();

                menu.MenuPrice = queryFoodMenu.FoodMenuPrice + queryDrinksMenu.DrinksMenuPrice;

                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.MenuId == id);
        }
    }
}
