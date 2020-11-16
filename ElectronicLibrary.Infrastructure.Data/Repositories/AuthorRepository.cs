using ElectronicLibrary.Domain.Core;
using ElectronicLibrary.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Data.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        private LibraryContext _context;
        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Author item)
        {
            try
            {
                await _context.Authors.AddAsync(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            try
            {
                return await _context.Authors.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    return await _context.Authors.Where(a => a.Id == id).FirstOrDefaultAsync();
                }
                throw new ArgumentException("Author id is not valid");
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
