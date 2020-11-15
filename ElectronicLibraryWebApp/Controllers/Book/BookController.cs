using System;
using System.Threading.Tasks;
using ElectronicLibrary.Domain.Core;
using ElectronicLibrary.Domain.Interfaces;
using ElectronicLibrary.Services.Interfaces;
using ElectronicLibraryWebApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicLibraryWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookRepository<Book> _bookRepository;
        private IImageService _imageService;
        private IHostingEnvironment _env;
        public BookController(
            IBookRepository<Book> bookRepository,
            IImageService imageService,
            IHostingEnvironment env
            )
        {
            _bookRepository = bookRepository;
            _imageService = imageService;
            _env = env;
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
                    string publicRoot = _env.WebRootPath;
                    Book book = new Book
                    {
                        AuthorId = model.AuthorId,
                        GenreId = model.GenreId,
                        ImagePath = await _imageService.SaveImageAsync(publicRoot, model.ImagePath),
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
