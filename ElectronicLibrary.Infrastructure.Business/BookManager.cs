using ElectronicLibrary.Domain.Core;
using ElectronicLibrary.Domain.Core.Library;
using ElectronicLibrary.Domain.Interfaces;
using ElectronicLibrary.Services.Interfaces;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Business
{
    public class BookManager : IBookManager
    {
        private IBookRepository<Book> _repository;
        private IBookingRepository<Booking> _bookingRepository;
        public BookManager(
            IBookRepository<Book> repository,
            IBookingRepository<Booking> bookingRepository)
        {
            _repository = repository;
            _bookingRepository = bookingRepository;
        }
        public async Task<bool> IsBookAvailableAsync(int bookId)
        {
            var amount = await _repository.GetAmountByIdAsync(bookId);
            var amountOfUnavailable = _bookingRepository.GetUnavailableBookingsById(bookId);
            if (amount > amountOfUnavailable)
            {
                return true;
            }
            return false;
        }
    }
}
