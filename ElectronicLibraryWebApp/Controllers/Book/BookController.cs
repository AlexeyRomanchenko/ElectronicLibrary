using System;
using System.Threading.Tasks;
using ElectronicLibrary.Domain.Core;
using ElectronicLibrary.Domain.Interfaces;
using ElectronicLibraryWebApp.ViewModels;
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
                var books = await _bookRepository.GetAllAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    var book = await _bookRepository.GetByIdAsync(id);
                    return Ok(book);
                }
                throw new ArgumentException("Invalid parameter");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Book book = new Book
                    {
                        AuthorId = model.AuthorId,
                        GenreId = model.GenreId,
                        ImagePath = model.ImagePath,
                        PublishYear = model.PublishYear,
                        Name = model.Name,
                        TotalAmount = model.TotalAmount
                    };
                    await _bookRepository.CreateAsync(book);
                    await _bookRepository.SaveAsync();
                    return Ok();
                }
                throw new Exception("Book is not valid");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
