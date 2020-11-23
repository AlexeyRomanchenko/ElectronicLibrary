using ElectronicLibrary.Domain.Core.Identity;
using ElectronicLibrary.Domain.Interfaces;
using ElectronicLibraryWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectronicLibraryWebApp.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockedUserController : ControllerBase
    {
        private IUserRepository<User> _repository;
        public BlockedUserController(IUserRepository<User> repository)
        {
            _repository = repository;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var blockedUsers = await _repository.GetBlockedAsync();
                List<UserDataViewModel> users = new List<UserDataViewModel>();
                foreach (var blockedUser in blockedUsers)
                {
                    users.Add(new UserDataViewModel
                    {
                        Id = blockedUser.Id,
                        Username = blockedUser.UserName,
                        IsBlocked = blockedUser.IsBlocked
                    });
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] bool userStatus)
        {
            try
            {
                User userToChangeStatus = await _repository.GetByIdAsync(id);
                _repository.ChangeUserStatus(userToChangeStatus, userStatus);
                await _repository.SaveAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
