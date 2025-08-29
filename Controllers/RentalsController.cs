using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalAPI.Data;
using CarRentalAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly CarRentalContext _context;

        public RentalsController(CarRentalContext context)
        {
            _context = context;
        }

        // GET: api/Rentals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
        {
            return await _context.Rentals.Include(r => r.Car).Include(r => r.Client).ToListAsync();
        }

        // GET: api/Rentals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> GetRental(int id)
        {
            var rental = await _context.Rentals
                .Include(r => r.Car)
                .Include(r => r.Client)
                .FirstOrDefaultAsync(r => r.RentalID == id);

            if (rental == null)
            {
                return NotFound();
            }

            return rental;
        }

        // POST: api/Rentals
        [HttpPost]
        public async Task<ActionResult<Rental>> PostRental(Rental rental)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = _context.Cars.FirstOrDefault(c => c.CarID == rental.CarID);
            if (car == null)
            {
                return NotFound("Car not found.");
            }

            var client = _context.Clients.FirstOrDefault(c => c.ClientID == rental.ClientID);
            if (client == null)
            {
                return NotFound("Client not found.");
            }

            if (rental.ReturnDate == null || rental.ReturnDate <= rental.RentalDate)
            {
                return BadRequest("Return date must be after rental date.");
            }

            rental.DurationInMinutes = (int)((rental.ReturnDate.Value - rental.RentalDate).TotalMinutes);
            rental.TotalCost = car.PricePerMinute * rental.DurationInMinutes;

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRental), new { id = rental.RentalID }, rental);
        }

        // PUT: api/Rentals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRental(int id, Rental rental)
        {
            if (id != rental.RentalID)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = _context.Cars.FirstOrDefault(c => c.CarID == rental.CarID);
            if (car == null)
            {
                return NotFound("Car not found.");
            }

            var client = _context.Clients.FirstOrDefault(c => c.ClientID == rental.ClientID);
            if (client == null)
            {
                return NotFound("Client not found.");
            }

            if (rental.ReturnDate == null || rental.ReturnDate <= rental.RentalDate)
            {
                return BadRequest("Return date must be after rental date.");
            }

            rental.DurationInMinutes = (int)((rental.ReturnDate.Value - rental.RentalDate).TotalMinutes);
            rental.TotalCost = car.PricePerMinute * rental.DurationInMinutes;

            _context.Entry(rental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalExists(id))
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

        // DELETE: api/Rentals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }

            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Rentals/CalculateCost
        [HttpPost("CalculateCost")]
        public ActionResult<decimal> CalculateRentalCost([FromBody] RentalRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = _context.Cars.FirstOrDefault(c => c.CarID == request.CarID);
            if (car == null)
            {
                return NotFound("Car not found.");
            }

            if (request.ReturnDate <= request.RentalDate)
            {
                return BadRequest("Return date must be after rental date.");
            }

            int durationInMinutes = (int)((request.ReturnDate - request.RentalDate).TotalMinutes);
            decimal totalCost = car.PricePerMinute * durationInMinutes;

            return Ok(totalCost);
        }

        private bool RentalExists(int id)
        {
            return _context.Rentals.Any(e => e.RentalID == id);
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.CarID == id);
        }
    }
}