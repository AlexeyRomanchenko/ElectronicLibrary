using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string email, string subject, string message);
    }
}
