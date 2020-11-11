using System;
using System.Threading.Tasks;
using ElectronicLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectronicLibraryWebApp.Controllers
{
    [Route("api/book/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        private IBookManager _manager;
        public AvailabilityController(IBookManager manager)
        {
            _manager = manager;
        }
        // GET api/<AvailabilityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    return Ok(await _manager.IsBookAvailableAsync(id));
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
