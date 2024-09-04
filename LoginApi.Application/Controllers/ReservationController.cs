using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoginAPI.Service;
using LoginAPI.Core;


namespace LoginApi.Application.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class ReservationController : ControllerBase
        {
            private readonly IReservationService _reservationService;

            public ReservationController(IReservationService reservationService)
            {
                _reservationService = reservationService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAllReservations()
            {
                var reservations = await _reservationService.GetAllReservations();
                return Ok(reservations);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetReservationById(int id)
            {
                var reservation = await _reservationService.GetReservationById(id);
                if (reservation == null)
                {
                    return NotFound();
                }
                return Ok(reservation);
            }

            [HttpPost]
            public async Task<IActionResult> AddReservation([FromBody] Reservation reservation)
            {
                await _reservationService.AddReservation(reservation);
                return CreatedAtAction(nameof(GetReservationById), new { id = reservation.ReservationID }, reservation);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateReservation(int id, [FromBody] Reservation reservation)
            {
                if (id != reservation.ReservationID)
                {
                    return BadRequest();
                }

                await _reservationService.UpdateReservation(reservation);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteReservation(int id)
            {
                await _reservationService.DeleteReservation(id);
                return NoContent();
            }
        }
}
