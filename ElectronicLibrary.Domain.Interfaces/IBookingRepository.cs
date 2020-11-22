using ElectronicLibrary.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ElectronicLibrary.Domain.Interfaces
{
    public interface IBookingRepository<T> : IRepository<T>
    {
        int GetUnavailableBookingsById(int id);
        Task<T> GetBookedItemByIdAsync(int id);
        Task<int> CheckExpiredBookingsAsync();
        Task<IEnumerable<BookingNotification>> GetExpiredUserEmailsAsync();
        Task SetBookingAsNotifiedAsync(int bookingId);
    }
}
