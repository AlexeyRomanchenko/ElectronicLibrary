using System;
using System.Threading.Tasks;
using ElectronicLibrary.Domain.Core;
using ElectronicLibrary.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicLibraryWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookRepository<Book> _bookRepository;
        public BookController(IBookRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        // GET: api/<BookController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _bookRepository.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
              
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
