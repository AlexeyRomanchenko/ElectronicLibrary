using ElectronicLibrary.Domain.Core.Library;
using ElectronicLibrary.Domain.Interfaces;
using ElectronicLibrary.Services.Interfaces;
using ElectronicLibrary.Services.Models;
using System;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Business
{
    public class BookingManager : IBooking
    {
        private IRepository<Booking> _repository;
        public BookingManager(IRepository<Booking> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Reserve(BookingModel model)
        {
            try
            {
                Booking booking = new Booking
                {
                    Status = Status.Booking,
                    BookingDate = DateTime.UtcNow,
                    IssueDate = DateTime.UtcNow.AddDays(2)
                };
                await _repository.CreateAsync(booking);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public Task<bool> Take()
        {
            throw new NotImplementedException();
        }
    }
}
