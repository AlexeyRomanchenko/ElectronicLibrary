using ElectronicLibrary.Domain.Core;
using ElectronicLibrary.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var book =  await _context.Books.Where(b => b.Id == id)
                    .Include(a => a.Author)
                    .Include(g => g.Genre)
                    .Include(c => c.Comments)
                    .AsNoTracking().FirstOrDefaultAsync();
                return book;
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

        public async Task<IEnumerable<Book>> GetBooksByKeyNameAsync(string keyWord)
        {
            try
            {
                List<Book> books = await _context.Books.FromSqlRaw(@"SELECT a.Id, a.Name, a.PublishYear, a.AuthorId, a.GenreId, a.ImagePath, a.TotalAmount
                                                FROM Books a
                                                LEFT JOIN Authors b ON a.AuthorId = b.Id 
                                                LEFT JOIN Genres c ON a.GenreId = c.GenreId
                                                WHERE concat(a.Name,a.PublishYear, b.Firstname, b.Lastname, c.Name)" +
                                                   $"LIKE '%{keyWord}%'").AsNoTracking().ToListAsync();
                return books;
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
    }
}
