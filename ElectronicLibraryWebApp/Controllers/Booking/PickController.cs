using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectronicLibraryWebApp.Controllers.Booking
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
        // GET: api/<PickController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PickController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PickController>
        [HttpPost]
        public IActionResult Post([FromBody] int id)
        {
            return BadRequest();
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

        // DELETE api/<PickController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
