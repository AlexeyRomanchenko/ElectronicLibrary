using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Interfaces
{
    public interface IBookRepository<T> : IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetBooksByKeyNameAsync(string key);
        Task<int> GetAmountByIdAsync();
    }
}
