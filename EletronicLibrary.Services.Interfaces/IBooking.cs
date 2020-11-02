using System.Threading.Tasks;

namespace EletronicLibrary.Services.Interfaces
{
    public interface IBooking
    {
        Task<bool> Reserve();
        Task<bool> Take(); 
    }
}
