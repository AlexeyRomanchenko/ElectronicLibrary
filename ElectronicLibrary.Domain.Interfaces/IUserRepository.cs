using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Interfaces
{
    public interface IUserRepository<T> where T: IdentityUser
    {
        Task<IEnumerable<T>> GetBlockedAsync();
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetByIdAsync(string id);
        void ChangeUserStatus(T user, bool userStatus);
        Task<bool> SaveAsync();
        Task<bool> IsExistsAsync(string username);
    }
}
