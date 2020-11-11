using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Interfaces
{
    public interface ICommentRepository<T> : IRepository<T>
    {
        Task<IEnumerable<T>> GetByBookIdAsync(int id);
        Task<bool> BlockAsync(int id);
    }
}
