using ElectronicLibrary.Domain.Core;
using ElectronicLibrary.Domain.Core.Identity;
using ElectronicLibrary.Infrastructure.Data;
using ElectronicLibrary.Infrastructure.Data.Repositories;
using ElectronicLibrary.Services.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ElectronicLibrary.Infrastructure.Business.UnitTests
{
    public class BookManagerShould
    {
        private DbContextOptions<LibraryContext> GetFakeConnection()
        {
            var sb = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(sb.ToString());
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseSqlite(connection)
                .Options;
            return options;
        }
        public int GenerateBookId(LibraryContext context, int amount)
        {
            try
            {
                var book = new Domain.Core.Book
                {
                    Author = new Domain.Core.Author
                    {
                        Firstname = "Alex",
                        Lastname = "Romanchenko"
                    },
                    Genre = new Domain.Core.Genre
                    {
                        Name = "Thriller"
                    },
                    Name = "Story tells",
                    TotalAmount = amount
                };
                context.Books.Add(book);
                context.SaveChanges();
                return book.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private string GetGeneratedUserId(LibraryContext context)
        {
            try
            {
                var user = new User
                {
                    IsBlocked = false,
                    Email = "romanchenko.oleksii@gmail.com",
                    UserName = "romanchenko.oleksii@gmail.com"
                };
                context.Users.Add(user);
                context.SaveChanges();
                return user.Id;
            }
            catch (Exception)
            {
                throw;
            };
            
        }
        private BookingModel GetBookingModel(LibraryContext context, int bookId)
        {
            try
            {
                string userId = GetGeneratedUserId(context);
                return new BookingModel(bookId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Fact]
        public async Task ShowBookIsAvailable()
        {
            try
            {
                var options = GetFakeConnection();
                using (var context = new LibraryContext(options))
                {
                    await context.Database.OpenConnectionAsync();
                    context.Database.EnsureCreated();

                    var bookId = GenerateBookId(context, 2);
                    var repository = new BookRepository(context);
                    var bookingRepository = new BookingRepository(context);
                    var manager = new BookManager(repository, bookingRepository);

                    var isAvailable = await manager.IsBookAvailableAsync(bookId);
                    Assert.True(isAvailable);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        [Fact]
        public async Task ShowBookIsUnavailable()
        {
            try
            {
                var options = GetFakeConnection();
                using (var context = new LibraryContext(options))
                {
                    await context.Database.OpenConnectionAsync();
                    context.Database.EnsureCreated();

                    var repository = new BookRepository(context);
                    var bookingRepository = new BookingRepository(context);
                    BookingManager bookingManager = new BookingManager(bookingRepository);
                    var manager = new BookManager(repository, bookingRepository);

                    var bookId = GenerateBookId(context, 1);
                    var bookingModel = GetBookingModel(context, bookId);
                    int bookingId = await bookingManager.ReserveAsync(bookingModel);
                    if (bookingId > 0)
                    {
                        var isAvailable = await manager.IsBookAvailableAsync(bookId);
                        Assert.False(isAvailable);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
