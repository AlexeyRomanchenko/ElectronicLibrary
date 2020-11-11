using ElectronicLibrary.Domain.Core.Library;
using ElectronicLibrary.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Data.Repositories
{
    public class CommentsRepository : ICommentRepository<Comment>
    {
        private LibraryContext _context;
        public CommentsRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Comment item)
        {
            try
            {
               await _context.Comments.AddAsync(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<IEnumerable<Comment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Comments.Where(c => c.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Comment>> GetByBookIdAsync(int id)
        {
            try
            {
                return await _context.Comments.Where(e => e.BookId == id).ToListAsync(); 
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

        public async Task<bool> BlockAsync(int id)
        {
            try
            {
                Comment comment = await GetByIdAsync(id);
                if (comment is null)
                {
                    throw new ArgumentException("Comment was not found");
                }
                comment.IsBlocked = true;
                _context.Entry(comment).State = EntityState.Modified;
                await SaveAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
