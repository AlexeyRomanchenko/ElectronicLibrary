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
    public class BookingShould
    {
        //[Fact]
        //public async Task ToBeCreated()
        //{
        //    var sb = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
        //    var connection = new SqliteConnection(sb.ToString());
        //    var options = new DbContextOptionsBuilder<LibraryContext>()
        //        .UseSqlite(connection)
        //        .Options;

        //    using (LibraryContext context = new LibraryContext(options))
        //    {
        //        await context.Database.OpenConnectionAsync();
        //        context.Database.EnsureCreated();

        //        var repository = new BookingRepository(context);
        //        var rowsChanged = await repository.CheckExpiredBookingsAsync();
        //        Assert.NotEqual(-1, rowsChanged);
        //    }
        //}
    }
}
