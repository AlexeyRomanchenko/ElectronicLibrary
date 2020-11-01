using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Interfaces
{
    public interface IBookRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T item);
        Task<T> GetById(int id);
    }
}
