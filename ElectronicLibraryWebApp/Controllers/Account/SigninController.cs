using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectronicLibrary.Domain.Core.Identity;
using ElectronicLibraryWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectronicLibraryWebApp.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class SigninController : ControllerBase
    {
        private SignInManager<User> _signInManager;
        public SigninController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }
        // POST api/<SigninController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserViewModel model)
        {
            try
            {
                User user = new User();
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                if (result.Succeeded)
                {
                    return Ok();
                }
                return Unauthorized();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
