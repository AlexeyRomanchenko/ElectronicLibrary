using ElectronicLibrary.Domain.Core;
using ElectronicLibrary.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Data.Repositories
{
    public class BookRepository : IBookRepository<Book>
    {
        public LibraryContext _context;
        public BookRepository(LibraryContext context)
        {
            _context = context;
        }
        public Task CreateAsync(Book book)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.Include(e=>e.Author).Include(e=>e.Genre).ToListAsync();
        }

        public Task<Book> GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
