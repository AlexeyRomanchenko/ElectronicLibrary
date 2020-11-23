using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Interfaces
{
    public interface IUserRepository<T> where T: IdentityUser
    {
        Task<IEnumerable<T>> GetBlockedAsync();
        Task<T> GetByIdAsync(string id);
        void ChangeUserStatus(T user, bool userStatus);
        Task<int> SaveAsync();
    }
}
