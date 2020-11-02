using System;
using System.Threading.Tasks;
using ElectronicLibrary.Domain.Core.Identity;
using ElectronicLibraryWebApp.Helpers;
using ElectronicLibraryWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        private UserManager<User> _userManager;
        private JWTHelper _jwtHelper;
        public SigninController(SignInManager<User> signInManager,
            UserManager<User> userManager,
            JWTHelper jwtHelper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtHelper = jwtHelper;
        }

        [HttpGet]
        [Authorize]
        public string Get()
        {
            return "authorized";
        }
        // POST api/<SigninController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] UserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                    if (result.Succeeded)
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
                    return Unauthorized();
                }
                throw new ArgumentException("User model is not valid");               
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
