using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Interfaces
{
    public interface ILoggerRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAsync();
    }
}
