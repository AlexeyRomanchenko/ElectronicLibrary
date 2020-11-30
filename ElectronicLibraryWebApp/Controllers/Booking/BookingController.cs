using System;
using System.Threading.Tasks;
using ElectronicLibrary.Domain.Core.Identity;
using ElectronicLibrary.Domain.Interfaces;
using ElectronicLibrary.Services.Interfaces;
using ElectronicLibrary.Services.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ElectronicLibrary.Domain.Core.Library;

namespace ElectronicLibraryWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingManager _bookingManager;
        private IBookingRepository<Booking> _repository;
        private UserManager<User> _userManager;
        public BookingController(
            IBookingManager bookingManager,
            IBookingRepository<Booking> repository,
            UserManager<User> userManager)
        {
            _bookingManager = bookingManager;
            _userManager = userManager;
            _repository = repository;
        }

        public async Task<IActionResult> Get()
        {
            try
            {
                var bookings = await _repository.GetAllAsync();
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] int bookId)
        {
            try
            {
                if (bookId > 0)
                {
                    User user = await _userManager.FindByNameAsync("romanchenko.oleksii@gmail.com");
                    BookingModel model = new BookingModel(bookId, user.Id);
                    int bookingId = await _bookingManager.ReserveAsync(model);
                    return Ok(bookingId);
                }
                throw new ArgumentOutOfRangeException("book is not valid");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repository.RemoveBookingAsync(id);
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
