#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiFlorence;
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
                         join payment in _context.Payments on reservations.PaymentId equals payment.PaymentId
                         where reservations.UserId == idUser
                         select new
                         {
                             reservationDateEvent = reservations.DateEvent,
                             reservationDateReservation = reservations.ReservationDate,
                             reservationTypeEvent = reservations.ReservationTypeEvent,
                             reservationPeople = reservations.NrPeople,
                             reservationStatus = reservations.StatusReservation,
                             reservationMenuPrice = menu.MenuPrice*reservations.NrPeople,
                             reservationMenuName = foodMenu.FoodMenuName,
                             reservationMenuAvans = payment.AmountPayment,
                             reservationDiscount=reservations.DiscountId

                         }).ToList();
            return Ok(query);
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
    }
}
