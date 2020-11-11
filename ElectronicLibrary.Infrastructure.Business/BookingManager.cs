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
        public BookingManager(IBookingRepository<Booking> repository)
        {
            _repository = repository;
        }
        public async Task<bool> ReserveAsync(BookingModel model)
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
                await _repository.CreateAsync(booking);
                await _repository.SaveAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        private int GetUnavailableBooksByBookId(int bookId)
        {
            return _repository.GetUnavailableBookingsById(bookId);
        }
  

        public Task<bool> TakeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
