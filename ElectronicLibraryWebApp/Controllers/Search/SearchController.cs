using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicLibrary.Domain.Core;
using ElectronicLibrary.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectronicLibraryWebApp.Controllers.Search
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private IBookRepository<Book> _repository;
        public SearchController(IBookRepository<Book> repository)
        {
            _repository = repository;
        }

        // GET api/<SearchController>/5
        [HttpGet("{key}")]
        public async Task<IActionResult> Get(string key)
        {
            try
            {
                if (String.IsNullOrEmpty(key?.Trim()))
                {
                    throw new ArgumentNullException("key is not valid");
                }
                var books = await _repository.GetBooksByKeyNameAsync(key);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
