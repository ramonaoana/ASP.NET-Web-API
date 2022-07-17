#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiFlorence;
using WebApiFlorence.Classes;
using WebApiFlorence.Data;
using Wkhtmltopdf.NetCore;

namespace WebApiFlorence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly DataContext _context;
        readonly IGeneratePdf _generatedPdf;
        private static int counter = 0;

        public DocumentsController(DataContext context,IGeneratePdf generatePdf)
        {
            _context = context;
            _generatedPdf = generatePdf;
        }

        // GET: api/Documents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetDocuments()
        {
            return await _context.Documents.ToListAsync();
        }

        // GET: api/Documents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);

            if (document == null)
            {
                return NotFound();
            }

            return document;
        }

        // PUT: api/Documents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocument(int id, Document document)
        {
            if (id != document.DocumentId)
            {
                return BadRequest();
            }

            _context.Entry(document).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentExists(id))
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


        [HttpGet("getDefaultContract/{reservationId}")]
        public Task<byte[]> GetDefaultContract(int reservationId)
        {
            //creare contract

            Document document = new Document();
            ReservationDetails res = new ReservationDetails();
            counter++;
            res.DocumentNumber = counter;

            document.SigningDate = DateTime.Now;
            String date = DateTime.Now.ToString("dd/MM/yyyy");
            res.DocumentDate = date;

            DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            String currentDate = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            res.currentDate = currentDate;



            var queryReservation = (from reservation in _context.Reservations
                                    where reservation.ReservationId == reservationId
                                    select reservation).FirstOrDefault();

            res.TotalPrice = (Double)queryReservation.ReservationAmount;

            res.ReservationNrPeople = queryReservation.NrPeople.ToString();
            
            DateTime dateDocument = queryReservation.DateEvent.Value;
            String datee = dateDocument.ToString("dd/MM/yyyy");
            res.ReservationDate = datee;

            var queryUser = (from reservation in _context.Reservations
                             join user in _context.Users on reservation.UserId equals user.UserId
                             where reservation.ReservationId == reservationId
                             select user).FirstOrDefault();

            res.FirstName = queryUser.FirstName;
            res.LastName = queryUser.LastName;
            res.Addresse = queryUser.Address;
            res.Town = queryUser.Town;
            res.County = queryUser.County;
            res.CNP = queryUser.CNP;

            var queryMenu = (from reservation in _context.Reservations
                             join menu in _context.Menus on reservation.MenuId equals menu.MenuId
                             where reservation.ReservationId == reservationId
                             select menu).FirstOrDefault();

            res.MenuPrice = queryMenu.MenuPrice;
            String type = "";
            switch (queryMenu.MenuTypeEvent)
            {
                case 0:
                    type = "Nunta";
                    break;

                case 1:
                    type = "Botez";
                    break;
                case 2:
                    type = "Petrecere";
                    break;
                default:
                    break;

            }
            res.ReservationTypeEvent = type;

            var queryFoodMenu = (from menu in _context.Menus
                                 join foodMenu in _context.FoodMenus on menu.FoodMenuId equals foodMenu.FoodMenuId
                                 where menu.MenuName == queryMenu.MenuName
                                 select new
                                 {
                                     foodMenu = foodMenu,
                                     menuDetails = menu
                                 }).FirstOrDefault();

            var queryDrinksMenu = (from menu in _context.Menus
                                   join drinksMenu in _context.DrinksMenus on menu.DrinksMenuId equals drinksMenu.DrinksMenuId
                                   where menu.MenuName == queryMenu.MenuName
                                   select new
                                   {
                                       drinksMenu
                                   }).FirstOrDefault();

            res.MenuName = queryFoodMenu.foodMenu.FoodMenuName;
            res.FoodMenuPrice = queryFoodMenu.foodMenu.FoodMenuPrice;
            res.FoodMenuName = queryFoodMenu.foodMenu.FoodMenuName;
            res.DrinksMenuPrice = queryDrinksMenu.drinksMenu.DrinksMenuPrice;
            res.Advance = 0;

            var queryDishes = (from foodMenu in _context.FoodMenus
                               join foodMenuDishes in _context.FoodMenuDishes on foodMenu.FoodMenuId equals foodMenuDishes.FoodMenuId
                               join dishes in _context.Dishes on foodMenuDishes.DishId equals dishes.DishId
                               where foodMenu.FoodMenuId == queryFoodMenu.foodMenu.FoodMenuId
                               select dishes).ToList();

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
            String firstListProducts = "";
            String secondListProducts = "";
            String thirdListProducts = "";
            String fourthListProducts = "";

            res.FirstDish = list.ElementAt(0).dish.DishName;
            for (int i = 0; i < list.ElementAt(0).productsList.Count; i++)
            {
                firstListProducts += list.ElementAt(0).productsList.ElementAtOrDefault(i).ProductName + ",";
            }
            firstListProducts.Substring(0, firstListProducts.Length - 2);

            res.SecondDish = list.ElementAt(1).dish.DishName;
            for (int i = 0; i < list.ElementAt(1).productsList.Count; i++)
            {
                secondListProducts += list.ElementAt(1).productsList.ElementAtOrDefault(i).ProductName + ",";
            }
            secondListProducts.Substring(0, secondListProducts.Length - 2);


            res.ThirdDish = list.ElementAt(2).dish.DishName;
            for (int i = 0; i < list.ElementAt(2).productsList.Count; i++)
            {
                thirdListProducts += list.ElementAt(2).productsList.ElementAtOrDefault(i).ProductName + ",";
            }
            thirdListProducts.Substring(0, thirdListProducts.Length - 2);

            res.FourthDish = list.ElementAt(3).dish.DishName;
            for (int i = 0; i < list.ElementAt(3).productsList.Count; i++)
            {
                fourthListProducts += list.ElementAt(3).productsList.ElementAtOrDefault(i).ProductName + ",";
            }
            fourthListProducts.Substring(0, fourthListProducts.Length - 2);

            res.FirstDishProducts = firstListProducts;
            res.SecondDishProducts = secondListProducts;
            res.ThirdDishProducts = thirdListProducts;
            res.FourthDishProducts = fourthListProducts;

            var queryPackages = (from packagesReservation in _context.ReservationPackages
                                 where packagesReservation.ReservationId == reservationId
                                 select packagesReservation).ToList();

            Double sum = 0;

            if (queryPackages.Count > 0)
            {
                foreach (var p in queryPackages)
                {
                    var queryPackage = (from package in _context.Packages
                                        where package.PackageId == p.PackageId
                                        select package).FirstOrDefault();
                    sum += queryPackage.PricePackage;
                }
            }
            res.AmountPackages = sum;
 

            var array = _generatedPdf.GetByteArray("Views/Contract.cshtml", res);
            return array;

        }

        [HttpGet("getAndSaveContract/{reservationId}")]
        public async Task<byte[]> GetAndSaveContractAsync(int reservationId)
        {
            //creare contract

            Document document = new Document();
            ReservationDetails res = new ReservationDetails();
            res.DocumentNumber = counter;

            document.SigningDate = DateTime.Now;
            String date = DateTime.Now.ToString("dd/MM/yyyy");
            res.DocumentDate = date;

            DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            String currentDate = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            res.currentDate = currentDate;

            var queryReservation = (from reservation in _context.Reservations
                                    where reservation.ReservationId == reservationId
                                    select reservation).FirstOrDefault();

            res.TotalPrice = (Double)queryReservation.ReservationAmount;

            var queryPayment = (from reservation in _context.Reservations
                                join payment in _context.Payments on reservation.PaymentId equals payment.PaymentId
                                where reservation.ReservationId == reservationId
                                select payment).FirstOrDefault();

           
            res.Advance = queryPayment.AmountPayment;
           

            res.ReservationNrPeople = queryReservation.NrPeople.ToString();
            DateTime dateDocument = queryReservation.DateEvent.Value;
            String datee = dateDocument.ToString("dd/MM/yyyy");
            res.ReservationDate = datee;
            res.ReservationDate = datee;

            var queryUser = (from reservation in _context.Reservations
                             join user in _context.Users on reservation.UserId equals user.UserId
                             where reservation.ReservationId == reservationId
                             select user).FirstOrDefault();

            res.FirstName = queryUser.FirstName;
            res.LastName = queryUser.LastName;
            res.Addresse = queryUser.Address;
            res.Town = queryUser.Town;
            res.County = queryUser.County;
            res.CNP = queryUser.CNP;

            var queryMenu = (from reservation in _context.Reservations
                             join menu in _context.Menus on reservation.MenuId equals menu.MenuId
                             where reservation.ReservationId == reservationId
                             select menu).FirstOrDefault();

            res.MenuPrice = queryMenu.MenuPrice;
            String type = "";
            switch (queryMenu.MenuTypeEvent)
            {
                case 0:
                    type = "Nunta";
                    break;

                case 1:
                    type = "Botez";
                    break;
                case 2:
                    type = "Petrecere";
                    break;
                default:
                    break;

            }
            res.ReservationTypeEvent = type;

            var queryFoodMenu = (from menu in _context.Menus
                                 join foodMenu in _context.FoodMenus on menu.FoodMenuId equals foodMenu.FoodMenuId
                                 where menu.MenuName == queryMenu.MenuName
                                 select new
                                 {
                                     foodMenu = foodMenu,
                                     menuDetails = menu
                                 }).FirstOrDefault();

            var queryDrinksMenu = (from menu in _context.Menus
                                   join drinksMenu in _context.DrinksMenus on menu.DrinksMenuId equals drinksMenu.DrinksMenuId
                                   where menu.MenuName == queryMenu.MenuName
                                   select new
                                   {
                                       drinksMenu
                                   }).FirstOrDefault();

            res.MenuName = queryFoodMenu.foodMenu.FoodMenuName;
            res.FoodMenuPrice = queryFoodMenu.foodMenu.FoodMenuPrice;
            res.FoodMenuName = queryFoodMenu.foodMenu.FoodMenuName;
            res.DrinksMenuPrice = queryDrinksMenu.drinksMenu.DrinksMenuPrice;


            var queryDishes = (from foodMenu in _context.FoodMenus
                               join foodMenuDishes in _context.FoodMenuDishes on foodMenu.FoodMenuId equals foodMenuDishes.FoodMenuId
                               join dishes in _context.Dishes on foodMenuDishes.DishId equals dishes.DishId
                               where foodMenu.FoodMenuId == queryFoodMenu.foodMenu.FoodMenuId
                               select dishes).ToList();

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
            String firstListProducts = "";
            String secondListProducts = "";
            String thirdListProducts = "";
            String fourthListProducts = "";

            res.FirstDish = list.ElementAt(0).dish.DishName;
            for (int i = 0; i < list.ElementAt(0).productsList.Count; i++)
            {
                firstListProducts += list.ElementAt(0).productsList.ElementAtOrDefault(i).ProductName + ",";
            }
            firstListProducts.Substring(0, firstListProducts.Length - 2);

            res.SecondDish = list.ElementAt(1).dish.DishName;
            for (int i = 0; i < list.ElementAt(1).productsList.Count; i++)
            {
                secondListProducts += list.ElementAt(1).productsList.ElementAtOrDefault(i).ProductName + ",";
            }
            secondListProducts.Substring(0, secondListProducts.Length - 2);


            res.ThirdDish = list.ElementAt(2).dish.DishName;
            for (int i = 0; i < list.ElementAt(2).productsList.Count; i++)
            {
                thirdListProducts += list.ElementAt(2).productsList.ElementAtOrDefault(i).ProductName + ",";
            }
            thirdListProducts.Substring(0, thirdListProducts.Length - 2);

            res.FourthDish = list.ElementAt(3).dish.DishName;
            for (int i = 0; i < list.ElementAt(3).productsList.Count; i++)
            {
                fourthListProducts += list.ElementAt(3).productsList.ElementAtOrDefault(i).ProductName + ",";
            }
            fourthListProducts.Substring(0, fourthListProducts.Length - 2);

            res.FirstDishProducts = firstListProducts;
            res.SecondDishProducts = secondListProducts;
            res.ThirdDishProducts = thirdListProducts;
            res.FourthDishProducts = fourthListProducts;

            var queryPackages=(from packagesReservation in _context.ReservationPackages
                               where packagesReservation.ReservationId==reservationId
                               select packagesReservation).ToList();

            Double sum = 0;

            if (queryPackages.Count > 0)
            {
                foreach(var p in queryPackages)
                {
                    var queryPackage = (from package in _context.Packages
                                        where package.PackageId == p.PackageId
                                        select package).FirstOrDefault();
                    sum += queryPackage.PricePackage;
                }
            } 
            res.AmountPackages = sum;


            document.ContentDocument = await _generatedPdf.GetByteArray("Views/Contract.cshtml", res); ;
            _context.Documents.Add(document);
            _context.SaveChanges();

            queryReservation.DocumentId = document.DocumentId;
            queryReservation.StatusReservation = 1;
            queryReservation.ReservationAmount = res.TotalPrice;
            _context.SaveChanges();

            return document.ContentDocument;
        }




        // DELETE: api/Documents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentExists(int id)
        {
            return _context.Documents.Any(e => e.DocumentId == id);
        }
    }
}
