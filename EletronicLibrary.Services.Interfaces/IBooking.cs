using ElectronicLibrary.Services.Models;
using System.Threading.Tasks;

namespace ElectronicLibrary.Services.Interfaces
{
    public interface IBooking
    {
        Task<bool> Reserve(BookingModel model);
        Task<bool> Take(); 
    }
}
