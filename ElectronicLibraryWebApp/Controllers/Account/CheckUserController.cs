using ElectronicLibrary.Domain.Core.Identity;
using ElectronicLibrary.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ElectronicLibraryWebApp.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckUserController : ControllerBase
    {
        private IUserRepository<User> _repository;
        public CheckUserController(IUserRepository<User> repository)
        {
            _repository = repository;
        }
        [HttpGet("{username}")]
        public async Task<IActionResult> Get(string username)
        {
            try
            {
                if (string.IsNullOrEmpty(username?.Trim()))
                {
                    throw new ArgumentException("username is not valid");
                }
                bool isExist = await _repository.IsExistsAsync(username);
                return Ok(isExist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
