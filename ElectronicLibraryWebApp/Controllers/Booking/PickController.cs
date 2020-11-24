using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectronicLibraryWebApp.Controllers
{
    [Route("api/booking/busy")]
    [ApiController]
    public class PickController : ControllerBase
    {
        private IBookingManager _manager;
        public PickController(IBookingManager manager)
        {
            _manager = manager;
        }
        // PUT api/<PickController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            try
            {
                if (id > 0)
                {
                    var isSucceed = await _manager.TakeAsync(id);
                    if (isSucceed)
                    {
                        return Ok();
                    }
                    throw new ArgumentException("Could not take a booking");
                }
                throw new ArgumentException("Booking was not identified");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
