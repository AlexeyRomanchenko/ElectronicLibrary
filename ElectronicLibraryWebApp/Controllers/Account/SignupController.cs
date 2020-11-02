using System;
using System.Threading.Tasks;
using ElectronicLibrary.Domain.Core.Identity;
using ElectronicLibraryWebApp.Helpers;
using ElectronicLibraryWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicLibraryWebApp.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private UserManager<User> _userManager;
        private JWTHelper _jwtHelper;
        public SignupController(UserManager<User> userManager, JWTHelper jwtHelper)
        {
            _userManager = userManager;
            _jwtHelper = jwtHelper;
        }
        // POST api/<SignupController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm]RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = new User
                    {
                        Email = model.Username,
                        UserName = model.Username
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if(result.Succeeded)
                    {
                        var claims = _jwtHelper.GenerateIdentity(model.Username, "Admin");
                        string encodedJwt = _jwtHelper.GenerateToken(claims);
                        var response = new
                        {
                            access_token = encodedJwt,
                            username = model.Username
                        };
                        return Ok(response);
                    }
                }
                throw new ArgumentException("Register model is not valid");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

    }
}
