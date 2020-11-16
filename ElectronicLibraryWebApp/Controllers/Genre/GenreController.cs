using System;
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
    public class GenreController : ControllerBase
    {
        private IRepository<Genre> _repository;
        public GenreController(IRepository<Genre> repository)
        {
            _repository = repository;
        }
        // GET: api/<GenreRepository>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var genres = await _repository.GetAllAsync();
                return Ok(genres);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<GenreRepository>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var genre = await _repository.GetByIdAsync(id);
                return Ok(genre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<GenreRepository>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GenreViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Genre genre = new Genre
                    {
                        Name = model.Name
                    };
                    await _repository.CreateAsync(genre);
                    await _repository.SaveAsync();
                    return Ok();
                }
                throw new Exception("Genre is not valid");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
