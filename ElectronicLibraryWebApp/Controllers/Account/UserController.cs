using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectronicLibrary.Domain.Core.Identity;
using ElectronicLibrary.Domain.Interfaces;
using ElectronicLibraryWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectronicLibraryWebApp.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository<User> _repository;
        public UserController(IUserRepository<User> repository)
        {
            _repository = repository;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _repository.GetAsync();
                List<UserDataViewModel> _users = new List<UserDataViewModel>();
                foreach (var user in users)
                {
                    _users.Add(new UserDataViewModel
                    {
                        Id = user.Id,
                        IsBlocked = user.IsBlocked,
                        Username = user.UserName
                    });
                }
                return Ok(_users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
