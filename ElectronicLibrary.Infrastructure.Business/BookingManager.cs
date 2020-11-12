using ElectronicLibrary.Domain.Core.Library;
using ElectronicLibrary.Domain.Interfaces;
using ElectronicLibrary.Services.Interfaces;
using ElectronicLibrary.Services.Models;
using System;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Business
{
    public class BookingManager : IBookingManager
    {
        private IBookingRepository<Booking> _repository;
        private IBookManager _bookMananger;
        public BookingManager(
            IBookingRepository<Booking> repository,
            IBookManager bookManager
            )
        {
            _repository = repository;
            _bookMananger = bookManager;
        }
        public async Task<int> ReserveAsync(BookingModel model)
        {
            try
            {
                Booking booking = new Booking
                {
                    Status = Status.Booking,
                    BookingDate = DateTime.UtcNow,
                    IssueDate = DateTime.UtcNow.AddDays(2),
                    BookId = model._bookId,
                    UserId = model._userId
                };
                bool isAvailable = await _bookMananger.IsBookAvailableAsync(model._bookId);
                if (isAvailable)
                {
                    await _repository.CreateAsync(booking);
                    await _repository.SaveAsync();
                    return booking.Id;
                }
                throw new ArgumentException("No bookings were available");
            }
            catch (Exception)
            {
                throw;
            }
            
        } 

        public async Task<bool> TakeAsync(int bookingId)
        {
            try
            {
                if (bookingId > 0)
                {
                    var booking = await _repository.GetBookedItemByIdAsync(bookingId);
                    booking.Status = Status.Busy;
                    booking.BookingDate = DateTime.UtcNow;
                    booking.IssueDate = DateTime.UtcNow.AddDays(30);
                    await _repository.SaveAsync();
                    return true;
                }
                throw new ArgumentException("booking is not identified");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
