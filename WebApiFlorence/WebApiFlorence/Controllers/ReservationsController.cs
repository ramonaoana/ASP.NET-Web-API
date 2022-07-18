#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiFlorence;
using WebApiFlorence.Classes;
using WebApiFlorence.Data;

namespace WebApiFlorence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly DataContext _context;

        public ReservationsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        [HttpGet("getReservationsDates")]
        public IActionResult getReservationsDates()
        {
            var result = (from reservation in _context.Reservations
                          where reservation.StatusReservation==1
                          select new
                          {
                              dateEvent = reservation.DateEvent
                          }).ToList();
            return Ok(result);
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        
        [HttpGet("getReservationsByUser/{idUser}")]
        public IActionResult GetReservationsByUser(int idUser)
        {
            var query = (from reservations in _context.Reservations
                         join menu in _context.Menus on reservations.MenuId equals menu.MenuId
                         join foodMenu in _context.FoodMenus on menu.FoodMenuId equals foodMenu.FoodMenuId
                         where reservations.UserId == idUser
                         select new
                         {
                             reservationDateEvent = reservations.DateEvent,
                             reservationDateReservation = reservations.ReservationDate,
                             reservationTypeEvent = reservations.ReservationTypeEvent,
                             reservationPeople = reservations.NrPeople,
                             reservationStatus = reservations.StatusReservation,
                             reservationAmount= reservations.ReservationAmount,
                             reservationMenuName = foodMenu.FoodMenuName,
                             reservationMenuAvans = 0.1*reservations.ReservationAmount,
                             reservationDiscount=reservations.DiscountId

                         }).ToList();
            return Ok(query);
        }

        [HttpGet("getAllReservations")]
        public IActionResult GetAllReservations()
        {
            var query = (from reservations in _context.Reservations
                         join menu in _context.Menus on reservations.MenuId equals menu.MenuId
                         join foodMenu in _context.FoodMenus on menu.FoodMenuId equals foodMenu.FoodMenuId
                         join user in _context.Users on reservations.UserId equals user.UserId
                         join document in _context.Documents on reservations.DocumentId equals document.DocumentId
                         select new
                         {
                             reservationDateEvent = reservations.DateEvent,
                             reservationDateReservation = reservations.ReservationDate,
                             reservationTypeEvent = reservations.ReservationTypeEvent,
                             reservationPeople = reservations.NrPeople,
                             reservationStatus = reservations.StatusReservation,
                             reservationAmount = reservations.ReservationAmount,
                             reservationMenuName = foodMenu.FoodMenuName,
                             reservationMenuAvans = 0.1 * reservations.ReservationAmount,
                             reservationDiscount = reservations.DiscountId,
                             reservationUserLastName = user.LastName,
                             reservationUserFirstName = user.FirstName,
                             reservationUserCnp = user.CNP,
                             reservationUserEmail = user.Email,
                             reservationUserPhone = user.Phone,
                             reservationContract=document.ContentDocument

                         }).ToList();
            return Ok(query);
        }

        [HttpGet("getFirstReservationByUser/{idUser}")]
        public String GetFirstReservationByUser(int idUser)
        {
            DateTime currentDate = DateTime.Now;
            var query = (from reservations in _context.Reservations
                         where reservations.UserId == idUser && reservations.DateEvent > currentDate && reservations.StatusReservation==1
                         orderby reservations.DateEvent ascending
                         select reservations).FirstOrDefault();

            String response = "";
            if (query != null)
            {
                TimeSpan nrDays = (TimeSpan)(query.DateEvent - DateTime.Now);
                Double nr = nrDays.Days;
                response = "" + nr;
            }
            else response = "Not found";

            return response;
        }



        // PUT: api/Reservations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, Reservation reservation)
        {
            if (id != reservation.ReservationId)
            {
                return BadRequest();
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
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

        // POST: api/Reservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            var queryFoodMenu = (from menu in _context.Menus
                                 where menu.MenuId == reservation.MenuId
                                 select menu).FirstOrDefault();

            reservation.ReservationAmount = queryFoodMenu.MenuPrice*reservation.NrPeople;
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetReservation", new { id = reservation.ReservationId }, reservation);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.ReservationId == id);
        }

        [HttpGet("getReservationsCompletedUncompleted")]
        public ReportNumberOfReservations GetReservationsCompletedUncompleted()
        {

            ReportNumberOfReservations report = new ReportNumberOfReservations();

            var queryResCompleted = (from reservations in _context.Reservations
                         where reservations.StatusReservation == 1
                         select reservations).ToList();


            var queryResUncompleted = (from reservations in _context.Reservations
                                     where reservations.StatusReservation == 0
                                     select reservations).ToList();

            int nrCompleted = queryResCompleted.Count;
            int nrUncompleted = queryResUncompleted.Count;

            report.NrReservationsCompleted = nrCompleted;
            report.NrReservationsUncompleted = nrUncompleted;
            report.TotalNrOfReservations = nrCompleted + nrUncompleted;

            return report;


        }

        [HttpGet("getReservationsByMonth")]
        public IActionResult GetReservationsByMonth()
        {
            DateTime currentDate = DateTime.Now;
            var queryReservations = (from reservations in _context.Reservations
                            where reservations.StatusReservation == 1 && ((DateTime)reservations.DateEvent).Year==currentDate.Year
                            select reservations).ToList();

            var results = queryReservations.GroupBy(n => ((DateTime)n.DateEvent).Month)
                            .Select(g => new { Month = g.Key, Count = g.Count() }).ToList();
            List<int> values = new List<int>();            
            for(int i = 1; i < 13; i++)
            {
                int k = 0;
                foreach(var item in results)
                {
                    if (item.Month.Equals(i))
                    {
                        values.Add(item.Count);
                        k = 1;
                    } 
                }
                if (k == 0)
                {
                    values.Add(0);
                }
            }

            return Ok(values);
        }

        [HttpGet("getReservationsFromLastYear")]
        public IActionResult GetReservationFromLastYear()
        {
            DateTime currentDate = DateTime.Now;
            var queryReservationsLastYear = (from reservations in _context.Reservations
                                     where reservations.StatusReservation == 1 && ((DateTime)reservations.DateEvent).Year == currentDate.Year-1
                                     select reservations).ToList();


            var resultsLastYear = queryReservationsLastYear.GroupBy(n => ((DateTime)n.DateEvent).Month)
                            .Select(g => new { Month = g.Key, Count = g.Count() }).ToList();

            List<int> valuesLastYear = new List<int>();
            for (int i = 1; i < 13; i++)
            {
                int k = 0;
                foreach (var item in resultsLastYear)
                {
                    if (item.Month.Equals(i))
                    {
                        valuesLastYear.Add(item.Count);
                        k = 1;
                    }
                }
                if (k == 0)
                {
                    valuesLastYear.Add(0);
                }
            }
         

            return Ok(valuesLastYear);


        }

        [HttpGet("getReservationsForFiveYears")]
        public IActionResult GetReservationsForFiveYears()
        {
            DateTime currentDate = DateTime.Now;
            var queryReservations = (from reservations in _context.Reservations
                                     where reservations.StatusReservation == 1 && ((DateTime)reservations.DateEvent).Year >= currentDate.Year && ((DateTime)reservations.DateEvent).Year < currentDate.Year+5
                                     select reservations).ToList();

            var results = queryReservations.GroupBy(n => ((DateTime)n.DateEvent).Year)
                            .Select(g => new { Year = g.Key, Count = g.Count() }).ToList();


            List<int> values = new List<int>();
            for (int i = currentDate.Year; i < currentDate.Year+5; i++)
            {
                int k = 0;
                foreach (var item in results)
                {
                    if (item.Year.Equals(i))
                    {
                        values.Add(item.Count);
                        k = 1;
                    }
                }
                if (k == 0)
                {
                    values.Add(0);
                }
            }

            return Ok(values);


        }
    }


}
