using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicLibrary.Domain.Core;
using ElectronicLibrary.Domain.Interfaces;
using ElectronicLibraryWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectronicLibraryWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IRepository<Author> _repository;
        public AuthorController(IRepository<Author> repository)
        {
            _repository = repository;
        }
        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var authors = await _repository.GetAllAsync();
                return Ok(authors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST api/<AuthorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Author author = new Author
                    {
                        Firstname = model.Firstname,
                        Lastname = model.Lastname
                    };
                    await _repository.CreateAsync(author);
                    await _repository.SaveAsync();
                    return Ok();
                }
                throw new Exception("Author is not valid");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
