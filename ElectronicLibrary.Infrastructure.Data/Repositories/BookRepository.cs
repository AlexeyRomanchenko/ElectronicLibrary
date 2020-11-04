using ElectronicLibrary.Domain.Core;
using ElectronicLibrary.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Data.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        public LibraryContext _context;
        public BookRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Book book)
        {
           await _context.Books.AddAsync(book);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            try
            {
                return await _context.Books
                   .Include(e => e.Author)
                   .Include(e => e.Genre)
                   .AsNoTracking()
                   .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }          
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Books.Where(b => b.Id == id)
                    .Include(a => a.Author)
                    .Include(g => g.Genre)
                    .Include(c => c.Comments)
                    .AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
