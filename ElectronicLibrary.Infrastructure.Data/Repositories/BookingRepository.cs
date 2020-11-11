using ElectronicLibrary.Domain.Core.Library;
using ElectronicLibrary.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Data.Repositories
{
    public class BookingRepository : IBookingRepository<Booking>
    {
        private LibraryContext _context;
        public BookingRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Booking booking)
        {
            try
            {
                if (booking is null)
                {
                    throw new ArgumentException("booking is not valid");
                }
                await _context.Bookings.AddAsync(booking);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            try
            {
                return await _context.Bookings.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Booking> GetByIdAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    return _context.Bookings
                        .AsNoTracking()
                        .Where(b => b.Id == id)
                        .FirstOrDefaultAsync();
                }
                throw new ArgumentException("Booking is not valid");
            }
            catch(Exception)
            {
                throw;
            }
        }

        public int GetUnavailableBookingsById(int id)
        {
            try
            {
                if (id > 0)
                {
                    return  _context.Bookings.Where(e => e.Status == Status.Booking).Count();
                }
                throw new ArgumentNullException("booking is unavailable");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
