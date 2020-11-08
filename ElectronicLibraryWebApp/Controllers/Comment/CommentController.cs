using System;
using System.Threading.Tasks;
using ElectronicLibrary.Domain.Core.Identity;
using ElectronicLibrary.Domain.Core.Library;
using ElectronicLibrary.Domain.Interfaces;
using ElectronicLibraryWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace ElectronicLibraryWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentRepository<Comment> _repository;
        private UserManager<User> _userManager;
        public CommentController(
            ICommentRepository<Comment> repository,
            UserManager<User> userManager
            )
        {
            _repository = repository;
            _userManager = userManager;
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var comments = await _repository.GetByBookIdAsync(id);
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CommentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByNameAsync("romanchenko.oleksii@gmail.com");
                    if (user != null)
                    {
                        Comment comment = new Comment
                        {
                            Text = model.Text,
                            BookId = model.BookId,
                            UserId = user.Id
                        };
                        await _repository.CreateAsync(comment);
                        await _repository.SaveAsync();
                        return Ok();
                    }
                    return StatusCode(403);
                }
                throw new ArgumentException("Comment is not valid");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
