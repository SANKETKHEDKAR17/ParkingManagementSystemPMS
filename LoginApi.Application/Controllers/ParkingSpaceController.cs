using LoginAPI.Core;
using LoginAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace LoginApi.Application.Controllers
{
    public class ParkingSpaceController : Controller
 
        {
            private readonly IParkingSpaceService _parkingSpaceService;

            public ParkingSpaceController(IParkingSpaceService parkingSpaceService)
            {
                _parkingSpaceService = parkingSpaceService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAllParkingSpaces()
            {
                var parkingSpaces = await _parkingSpaceService.GetAllParkingSpaces();
                return Ok(parkingSpaces);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetParkingSpaceById(int id)
            {
                var parkingSpace = await _parkingSpaceService.GetParkingSpaceById(id);
                if (parkingSpace == null)
                {
                    return NotFound();
                }
                return Ok(parkingSpace);
            }

            [HttpPost]
            public async Task<IActionResult> AddParkingSpace([FromBody] ParkingSpace parkingSpace)
            {
                await _parkingSpaceService.AddParkingSpace(parkingSpace);
                return CreatedAtAction(nameof(GetParkingSpaceById), new { id = parkingSpace.ParkingSpaceID }, parkingSpace);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateParkingSpace(int id, [FromBody] ParkingSpace parkingSpace)
            {
                if (id != parkingSpace.ParkingSpaceID)
                {
                    return BadRequest();
                }

                await _parkingSpaceService.UpdateParkingSpace(parkingSpace);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteParkingSpace(int id)
            {
                await _parkingSpaceService.DeleteParkingSpace(id);
                return NoContent();
            }
        }
    }

