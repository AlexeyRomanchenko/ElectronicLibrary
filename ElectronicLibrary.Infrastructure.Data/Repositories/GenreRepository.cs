using ElectronicLibrary.Domain.Core;
using ElectronicLibrary.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Data.Repositories
{
    public class GenreRepository : IRepository<Genre>
    {
        private LibraryContext _context;
        public GenreRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Genre item)
        {
            try
            {
                if (item is null)
                {
                    throw new ArgumentNullException("Genre is not valid");
                }
                await _context.Genres.AddAsync(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            try
            {
                return await _context.Genres.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    return await _context.Genres.AsNoTracking().Where(g => g.Id == id).FirstOrDefaultAsync();
                }
                throw new ArgumentException("Genre is not valid");
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
    }
}
