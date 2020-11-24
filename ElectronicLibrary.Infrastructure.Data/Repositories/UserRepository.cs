using ElectronicLibrary.Domain.Core.Identity;
using ElectronicLibrary.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private LibraryContext _context;
        public UserRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetBlockedAsync()
        {
            try
            {
                return await _context.Users.Where(e => e.IsBlocked == true).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetByIdAsync(string id)
        {
            try
            {
                return await _context.Users.Where(e => e.Id == id).SingleOrDefaultAsync();
            }
            catch(Exception)
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

        public void ChangeUserStatus(User user, bool userStatus)
        {
            try
            {
                if (user is null)
                {
                    throw new ArgumentException("User is not valid");
                }
                user.IsBlocked = userStatus;
                _context.Entry(user).State = EntityState.Modified;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public async Task<bool> IsExistsAsync(string username)
        {
            try
            {
                var user = await _context.Users.Where(e => e.UserName == username).FirstOrDefaultAsync();
                return !(user is null); 
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
