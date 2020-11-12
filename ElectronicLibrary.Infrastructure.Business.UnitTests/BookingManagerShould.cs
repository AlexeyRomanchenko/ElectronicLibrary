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
    public class BookingManagerShould
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
        private int GenerateBookId(LibraryContext context, int amount)
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
        private BookingModel GetBookingModel(LibraryContext context, int amount)
        {
            try
            {
                string userId = GetGeneratedUserId(context);
                int bookId = GenerateBookId(context, amount);
                return new BookingModel(bookId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Fact]
        public async Task NotReserveIfUnavailable()
        {
            try
            {
                var options = GetFakeConnection();
                using (var context = new LibraryContext(options))
                {
                    await context.Database.OpenConnectionAsync();
                    context.Database.EnsureCreated();

                    var model = GetBookingModel(context, 1);
                    var bookRepository = new BookRepository(context);
                    var repository = new BookingRepository(context);
                    var bookManager = new BookManager(bookRepository, repository);
                    var manager = new BookingManager(repository, bookManager);

                    bool isFirstReserved =  await manager.ReserveAsync(model);
                    bool isSecondReserved = await manager.ReserveAsync(model);
                    Assert.True(isFirstReserved);
                    Assert.False(isSecondReserved);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
