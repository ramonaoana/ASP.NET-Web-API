using Microsoft.AspNetCore.Http;
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
    public class ReservationPackageController : ControllerBase
    {
        private readonly DataContext _context;

        public ReservationPackageController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationPackage>>> GetReservationPackages()
        {
            return await _context.ReservationPackages.ToListAsync();
        }


        [HttpGet("getReservationPackage")]
        public async Task<ActionResult<ReservationPackage>> GetReservationPackage([FromQuery]int reservationId, [FromQuery] int packageId)
        {
            var reservationPackage = await _context.ReservationPackages.FirstOrDefaultAsync(x => x.ReservationId == reservationId && x.PackageId == packageId);

            if (reservationPackage == null)
            {
                return NotFound();
            }

            return reservationPackage;
        }


        [HttpPost]
        public async Task<ActionResult<ReservationPackage>> PostReservationPackage(ReservationPackage reservationPackage)
        {
            _context.ReservationPackages.Add(reservationPackage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservationPackage", new { reservationId = reservationPackage.ReservationId, packageId = reservationPackage.ReservationId }, reservationPackage);
        }
    }
}
