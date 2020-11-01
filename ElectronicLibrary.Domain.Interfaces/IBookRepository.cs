using ElectronicLibrary.Domain.Core;
using System;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task GetAllAsync();
        Task CreateAsync(Book book);
        Task<Book> GetById(int id);
    }
}
