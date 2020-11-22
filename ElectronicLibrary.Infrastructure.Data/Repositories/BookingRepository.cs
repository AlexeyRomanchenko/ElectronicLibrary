using ElectronicLibrary.Domain.Core.Library;
using ElectronicLibrary.Domain.Interfaces;
using ElectronicLibrary.Services.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    return  _context.Bookings.Where(e => e.Status == Status.Booking || e.Status == Status.Busy).Count();
                }
                throw new ArgumentNullException("booking is unavailable");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Booking> GetBookedItemByIdAsync(int bookingId)
        {
            try
            {
                if (bookingId > 0)
                {
                    return await _context.Bookings
               .Where(
                   e => e.Id == bookingId &&
                   e.Status == Status.Booking
                   )
                   .FirstAsync();

                }
                throw new ArgumentException("Booking was not identified");
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("There was an error with finding your booking"); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> CheckExpiredBookingsAsync()
        {
            try
            {
                return await _context.Database.ExecuteSqlRawAsync("exec RemoveIssuedBookings");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<BookingNotification>> GetExpiredUserEmailsAsync()
        {
            try
            {
                List<BookingNotification> notifications = new List<BookingNotification>();
                using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("SELECT * from GetUsersWithExpiredBusyStatus()", connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync(System.Data.CommandBehavior.CloseConnection))
                        {
                            while (reader.Read())
                            {
                                notifications.Add(new BookingNotification
                                {
                                     Email = reader.GetString(reader.GetOrdinal("Email")),
                                     Book = reader.GetString(reader.GetOrdinal("Book")),
                                     BookingId = reader.GetInt32(reader.GetOrdinal("BookingId")),
                                     BookingDate = reader.GetDateTime(reader.GetOrdinal("BookingDate")),
                                });
                            }
                        }
                    }
                }
                return notifications;
            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}
