using System;
using System.Threading.Tasks;
using ElectronicLibrary.Domain.Core.Identity;
using ElectronicLibrary.Services.Interfaces;
using ElectronicLibrary.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace ElectronicLibraryWebApp.Controllers.Booking
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBooking _bookingManager;
        private UserManager<User> _userManager;
        public BookingController(IBooking bookingManager, UserManager<User> userManager)
        {
            _bookingManager = bookingManager;
            _userManager = userManager;
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] int bookId)
        {
            try
            {
                if (bookId > 0)
                {
                    User user = await _userManager.FindByNameAsync(User.Identity.Name);
                    BookingModel model = new BookingModel(bookId, user.Id);
                    bool isReserved = await _bookingManager.ReserveAsync(model);
                    return Ok(isReserved);
                }
                throw new ArgumentOutOfRangeException("book is not valid");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
