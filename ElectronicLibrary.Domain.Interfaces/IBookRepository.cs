using ElectronicLibrary.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Interfaces
{
    public interface IBookRepository<T> : IRepository<T> where T: class
    {
        Task<IEnumerable<Book>> GetBooksByKeyNameAsync(string key);
    }
}
