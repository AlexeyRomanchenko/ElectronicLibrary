using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Interfaces
{
    public interface IBookingRepository<T> : IRepository<T>
    {
        int GetUnavailableBookingsById(int id);
    }
}
