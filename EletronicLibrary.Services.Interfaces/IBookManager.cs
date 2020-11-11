using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Services.Interfaces
{
    public interface IBookManager
    {
        Task<bool> IsBookAvailableAsync(int id);
    }
}
