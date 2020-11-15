using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Services.Interfaces
{
    public interface IImageService
    {
        Task<string> SaveImageAsync(string path, string baseString);
    }
}
