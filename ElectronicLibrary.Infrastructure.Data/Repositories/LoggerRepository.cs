using ElectronicLibrary.Domain.Core.Library;
using ElectronicLibrary.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Data.Repositories
{
    public class LoggerRepository : ILoggerRepository<Log>
    {
        private LibraryContext _context;
        public LoggerRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Log>> GetAsync()
        {
            try
            {
                return await _context.Logs
                    .AsNoTracking()
                    .Include(u=>u.User)
                    .Include(b=>b.Book)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
