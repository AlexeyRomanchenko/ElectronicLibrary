using ElectronicLibrary.Domain.Core;
using ElectronicLibrary.Infrastructure.Data;
using ElectronicLibrary.Infrastructure.Data.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace ElectronicLibrary.Infrastructure.Tests
{
    public class BookShould
    {
        [Fact]
        public async Task ToBeCreated()
        {
            var sb = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(sb.ToString());
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseSqlite(connection)
                .Options;

            Book book = new Book
            {
                Name = "Test book",
                Author = new Author
                {
                    Firstname = "Firstame",
                    Lastname = "Surname"
                },
                Genre = new Genre
                {
                    Name = "Detective"
                },
                TotalAmount = 200
            };

            using (LibraryContext context = new LibraryContext(options))
            {
                await context.Database.OpenConnectionAsync();
                context.Database.EnsureCreated();

                var repository = new BookRepository(context);
                await repository.CreateAsync(book);
                await repository.SaveAsync();

                Assert.NotNull(await repository.GetAllAsync());
            }
        }
    }
}
