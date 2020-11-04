using System;
using System.Collections.Generic;
using System.Linq;
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

        [Authorize(Roles ="User")]
        [HttpGet]
        public string Get()
        {
            return $"you loginned {User.Identity.Name}";
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
                        User user = await _userManager.FindByNameAsync(model.Username);
                        IList<string> roles = await _userManager.GetRolesAsync(user);
                        string role = roles.FirstOrDefault();
                        if (user.IsBlocked)
                        {
                            string encodedJwt = _jwtHelper.GenerateToken(model.Username, role);
                            var response = new
                            {
                                access_token = encodedJwt,
                                username = model.Username
                            };
                            return Ok(response);
                        }
                        else
                        {
                            return StatusCode(403);
                        }

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
