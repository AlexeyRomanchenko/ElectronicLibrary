using ElectronicLibrary.Domain.Core;
using ElectronicLibrary.Domain.Interfaces;
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

        private async Task CreateFakeBookAsync(IRepository<Book> repository)
        {
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

            await repository.CreateAsync(book);
            await repository.SaveAsync();
        }
        [Fact]
        public async Task ToBeCreated()
        {
            var sb = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(sb.ToString());
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseSqlite(connection)
                .Options;

            using (LibraryContext context = new LibraryContext(options))
            {
                await context.Database.OpenConnectionAsync();
                context.Database.EnsureCreated();

                var repository = new BookRepository(context);
                await CreateFakeBookAsync(repository);
                Assert.NotNull(await repository.GetAllAsync());
            }
        }

        [Theory]
        [InlineData("net")]
        public async Task ToBeReturnedByKeywords(string key)
        {
            var connection = "Server=(localdb)\\mssqllocaldb;Database=ElectricLibrary;Trusted_Connection=True;MultipleActiveResultSets=true";
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseSqlServer(connection)
                .Options;
            using (LibraryContext context = new LibraryContext(options))
            {
                var repository = new BookRepository(context);
                var books = await repository.GetBooksByKeyNameAsync(key);

                Assert.NotNull(books);
                Assert.NotEmpty(books);
            }
        }
    }
}
