using ElectronicLibrary.Services.Models;
using System.Threading.Tasks;

namespace ElectronicLibrary.Services.Interfaces
{
    public interface IBookingManager
    {
        Task<int> ReserveAsync(BookingModel model);
        Task<bool> TakeAsync(int id); 
    }
}
