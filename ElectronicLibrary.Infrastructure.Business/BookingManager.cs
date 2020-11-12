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
                bool isAvailable = await _bookMananger.IsBookAvailableAsync(model._bookId);
                if (isAvailable)
                {
                    await _repository.CreateAsync(booking);
                    await _repository.SaveAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public Task<bool> TakeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
